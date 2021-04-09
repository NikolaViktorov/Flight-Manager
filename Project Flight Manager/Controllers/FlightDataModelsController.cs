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
    public class FlightDataModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightDataModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FlightDataModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flights.ToListAsync());
        }

        // GET: FlightDataModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightDataModel = await _context.Flights
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flightDataModel == null)
            {
                return NotFound();
            }

            return View(flightDataModel);
        }

        // GET: FlightDataModels/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlightDataModel flightDataModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightDataModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flightDataModel);
        }

        // GET: FlightDataModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightDataModel = await _context.Flights.FindAsync(id);
            if (flightDataModel == null)
            {
                return NotFound();
            }
            return View(flightDataModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, FlightDataModel flightDataModel)
        {
            if (id != flightDataModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightDataModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightDataModelExists(flightDataModel.Id))
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
            return View(flightDataModel);
        }

        // GET: FlightDataModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightDataModel = await _context.Flights
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flightDataModel == null)
            {
                return NotFound();
            }

            return View(flightDataModel);
        }

        // POST: FlightDataModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var flightDataModel = await _context.Flights.FindAsync(id);
            _context.Flights.Remove(flightDataModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // 
        private bool FlightDataModelExists(string id)
        {
            return _context.Flights.Any(e => e.Id == id);
        }
    }
}
