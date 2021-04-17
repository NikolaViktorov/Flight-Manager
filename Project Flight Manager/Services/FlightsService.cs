namespace Project_Flight_Manager.Services
{
    using Microsoft.EntityFrameworkCore;
    using Project_Flight_Manager.Data;
    using Project_Flight_Manager.Services.Contracts;
    using Project_Flight_Manager.ViewModels.Flights;
    using Project_Flight_Manager.ViewModels.Reservations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class FlightsService : IFlightsService
    {
        private readonly ApplicationDbContext db;

        public FlightsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<FlightDetailsViewModel> GetFlight(string flightId)
        {
            var flight = await this.db.Flights.Include(f => f.Reservations).FirstOrDefaultAsync(f => f.Id == flightId);

            var result = new FlightDetailsViewModel()
            {
                FlightId = flight.Id,
                FromLocation = flight.FromLocation,
                AirlineID = flight.AirlineID,
                AirlineName = flight.AirlineName,
                FlightDuration = (flight.DepatureTime - flight.ArrivalTime).TotalHours.ToString(),
                BusinessCapacity = flight.BusinessCapacity,
                Capacity = flight.Capacity,
                DepatureTime = flight.DepatureTime,
                PilotName = flight.PilotName,
                ToLocation = flight.ToLocation,
                Reservations = flight.Reservations.Select(r => new ReservationUserViewModel()
                {
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    TicketType = r.TicketType,
                }).ToList(),
            };

            return result;
        }

        public Task<List<FlightViewModel>> GetFlights(int count, string filter)
        {
            switch (filter)
            {
                case "airlineName":
                    return this.db.Flights
                        .Take(count)
                        .OrderBy(f => f.AirlineName).Select(f => new FlightViewModel()
                        {
                            FlightId = f.Id,
                            AirlineID = f.AirlineID,
                            FromLocation = f.FromLocation,
                            AirlineName = f.AirlineName,
                            ArrivalTime = f.ArrivalTime,
                            BusinessCapacity = f.BusinessCapacity,
                            Capacity = f.Capacity,
                            DepatureTime = f.DepatureTime,
                            PilotName = f.PilotName,
                            ToLocation = f.ToLocation,
                        }).ToListAsync();
                case "airlineId":
                    return this.db.Flights
                         .Take(count)
                        .OrderBy(f => f.AirlineID).Select(f => new FlightViewModel()
                        {
                            FlightId = f.Id,
                            AirlineID = f.AirlineID,
                            FromLocation = f.FromLocation,
                            AirlineName = f.AirlineName,
                            ArrivalTime = f.ArrivalTime,
                            BusinessCapacity = f.BusinessCapacity,
                            Capacity = f.Capacity,
                            DepatureTime = f.DepatureTime,
                            PilotName = f.PilotName,
                            ToLocation = f.ToLocation,
                        }).ToListAsync();
                default:
                    return this.db.Flights
                        .Take(count)
                        .Select(f => new FlightViewModel()
                        {
                            FlightId = f.Id,
                            AirlineID = f.AirlineID,
                            FromLocation = f.FromLocation,
                            AirlineName = f.AirlineName,
                            ArrivalTime = f.ArrivalTime,
                            BusinessCapacity = f.BusinessCapacity,
                            Capacity = f.Capacity,
                            DepatureTime = f.DepatureTime,
                            PilotName = f.PilotName,
                            ToLocation = f.ToLocation,
                        }).ToListAsync();
            }
        }
    }
}
