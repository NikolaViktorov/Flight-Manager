using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Flight_Manager.Data;
using Project_Flight_Manager.Models;
using Project_Flight_Manager.Services.Contracts;
using Project_Flight_Manager.ViewModels.Reservations;

namespace Project_Flight_Manager.Controllers
{
    public class ReservationDataModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IReservationsService reservationsService;

        public ReservationDataModelsController(ApplicationDbContext context, IReservationsService reservationsService)
        {
            _context = context;
            this.reservationsService = reservationsService;
        }

        // GET: ReservationDataModels
        public async Task<IActionResult> Index()
        {
            var model = await _context.Reservations.ToListAsync();
            return View(model);
        }

        // GET: ReservationDataModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationDataModel = await this.reservationsService.ReservationDetails(id);
            if (reservationDataModel == null)
            {
                return NotFound();
            }

            return this.View(reservationDataModel);
        }

        // GET: ReservationDataModels/Create
        public IActionResult Create(string flightId)
        {
            var model = new ReservationInputModel()
            {
                FlightId = flightId,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationInputModel model)
        {
            if (ModelState.IsValid)
            {
                await this.reservationsService.CreateReservation(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ReservationDataModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationDataModel = await _context.Reservations.FindAsync(id);
            if (reservationDataModel == null)
            {
                return NotFound();
            }
            var model = new ReservationEditInputModel()
            {
                FirstName = reservationDataModel.FirstName,
                LastName = reservationDataModel.LastName,
                EGN = reservationDataModel.EGN,
                MiddleName = reservationDataModel.MiddleName,
                Nationality = reservationDataModel.Nationality,
                TelNumber = reservationDataModel.TelNumber,
                TicketType = reservationDataModel.TicketType,
                ReservationId = id,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationEditInputModel reservationDataModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.reservationsService.EditReservation(reservationDataModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationDataModelExists(reservationDataModel.FirstName))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservationDataModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationDataModel = await _context.Reservations
                .FirstOrDefaultAsync(m => m.FirstName == id);
            if (reservationDataModel == null)
            {
                return NotFound();
            }

            return View(reservationDataModel);
        }

        [HttpPost("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var reservationDataModel = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservationDataModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationDataModelExists(string id)
        {
            return _context.Reservations.Any(e => e.FirstName == id);
        }
    }
}
