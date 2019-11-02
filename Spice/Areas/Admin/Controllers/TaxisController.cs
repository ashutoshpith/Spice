using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaxisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaxisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Taxis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Taxi.ToListAsync());
        }

        // GET: Admin/Taxis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxi = await _context.Taxi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxi == null)
            {
                return NotFound();
            }

            return View(taxi);
        }

        // GET: Admin/Taxis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Taxis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VendorId,RateCode,PassengerCount,TripTimeInSecs,TripDistance,PaymentType,FareAmount")] Taxi taxi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxi);
        }

        // GET: Admin/Taxis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxi = await _context.Taxi.FindAsync(id);
            if (taxi == null)
            {
                return NotFound();
            }
            return View(taxi);
        }

        // POST: Admin/Taxis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VendorId,RateCode,PassengerCount,TripTimeInSecs,TripDistance,PaymentType,FareAmount")] Taxi taxi)
        {
            if (id != taxi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxiExists(taxi.Id))
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
            return View(taxi);
        }

        // GET: Admin/Taxis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxi = await _context.Taxi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxi == null)
            {
                return NotFound();
            }

            return View(taxi);
        }

        // POST: Admin/Taxis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxi = await _context.Taxi.FindAsync(id);
            _context.Taxi.Remove(taxi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxiExists(int id)
        {
            return _context.Taxi.Any(e => e.Id == id);
        }
    }
}
