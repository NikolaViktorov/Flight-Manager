using Microsoft.EntityFrameworkCore;
using Project_Flight_Manager.Data;
using Project_Flight_Manager.Models;
using Project_Flight_Manager.Services.Contracts;
using Project_Flight_Manager.ViewModels.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Flight_Manager.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly ApplicationDbContext db;

        public ReservationsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task CreateReservation(ReservationInputModel input)
        {
            var flight = await this.db.Flights.FirstOrDefaultAsync(f => f.Id == input.FlightId);
            if (flight == null)
            {
                throw new ArgumentException("Invalid flight!");
            }

            var reservation = new ReservationDataModel()
            {
                FirstName = input.FirstName,
                MiddleName = input.MiddleName,
                LastName = input.LastName,
                EGN = input.EGN,
                Nationality = input.Nationality,
                TelNumber = input.TelNumber,
                TicketType = input.TicketType,
                Flight = flight,
                FlightId = flight.Id,
            };

            flight.Reservations.Add(reservation);

            await this.db.Reservations.AddAsync(reservation);
            await this.db.SaveChangesAsync();
        }

        public async Task EditReservation(ReservationEditInputModel reservationDataModel)
        {
            var reservation = await this.db.Reservations.FirstOrDefaultAsync(r => r.ReservationId == reservationDataModel.ReservationId);
            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found!");
            }

            reservation.FirstName = reservationDataModel.FirstName;
            reservation.MiddleName = reservationDataModel.MiddleName;
            reservation.LastName = reservationDataModel.LastName;
            reservation.EGN = reservationDataModel.EGN;
            reservation.Nationality = reservationDataModel.Nationality;
            reservation.TelNumber = reservationDataModel.TelNumber;
            reservation.TicketType = reservationDataModel.TicketType;

            await this.db.SaveChangesAsync();
        }

        public async Task<ReservationDetailsViewModel> ReservationDetails(string reservationId)
        {
            var reservation = await this.db.Reservations.Include(r => r.Flight).FirstOrDefaultAsync(r => r.ReservationId == reservationId);
            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found!");
            }

            return new ReservationDetailsViewModel()
            {
                FirstName = reservation.FirstName,
                MiddleName = reservation.MiddleName,
                LastName = reservation.LastName,
                EGN = reservation.EGN,
                Nationality = reservation.Nationality,
                TelNumber = reservation.TelNumber,
                TicketType = reservation.TicketType,
                FlightName = reservation.Flight.AirlineName,
            };
        }
    }
}
