using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Flight_Manager.Data;
using Project_Flight_Manager.Models;

namespace Project_Flight_Manager.Controllers
{
    public class ReservationDataModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationDataModelsController(ApplicationDbContext context)
        {
            _context = context;
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

            var reservationDataModel = await _context.Reservations
                .FirstOrDefaultAsync(m => m.FirstName == id);
            if (reservationDataModel == null)
            {
                return NotFound();
            }

            return this.View(reservationDataModel);
        }

        // GET: ReservationDataModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservationDataModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,MiddleName,LastName,EGN,TelNumber,Nationality,TicketType")] ReservationDataModel reservationDataModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationDataModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservationDataModel);
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
            return View(reservationDataModel);
        }

        // POST: ReservationDataModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,MiddleName,LastName,EGN,TelNumber,Nationality,TicketType")] ReservationDataModel reservationDataModel)
        {
            if (id != reservationDataModel.FirstName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationDataModel);
                    await _context.SaveChangesAsync();
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

        // GET: ReservationDataModels/Delete/5
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

        // POST: ReservationDataModels/Delete/5
        [HttpPost, ActionName("Delete")]
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
