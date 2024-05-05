using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MP.Models;

namespace MP.Controllers
{
    public class PickUpPointsController : Controller
    {
        private readonly MarketDbContext _context;

        public PickUpPointsController(MarketDbContext context)
        {
            _context = context;
        }

        // GET: PickUpPoints
        public async Task<IActionResult> Index()
        {
              return _context.PickUpPoints != null ? 
                          View(await _context.PickUpPoints.ToListAsync()) :
                          Problem("Entity set 'MarketDbContext.PickUpPoints'  is null.");
        }

        // GET: PickUpPoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PickUpPoints == null)
            {
                return NotFound();
            }

            var pickUpPoint = await _context.PickUpPoints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pickUpPoint == null)
            {
                return NotFound();
            }

            return View(pickUpPoint);
        }

        // GET: PickUpPoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PickUpPoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adress,Rating")] PickUpPoint pickUpPoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pickUpPoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pickUpPoint);
        }

        // GET: PickUpPoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PickUpPoints == null)
            {
                return NotFound();
            }

            var pickUpPoint = await _context.PickUpPoints.FindAsync(id);
            if (pickUpPoint == null)
            {
                return NotFound();
            }
            return View(pickUpPoint);
        }

        // POST: PickUpPoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adress,Rating")] PickUpPoint pickUpPoint)
        {
            if (id != pickUpPoint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pickUpPoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PickUpPointExists(pickUpPoint.Id))
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
            return View(pickUpPoint);
        }

        // GET: PickUpPoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PickUpPoints == null)
            {
                return NotFound();
            }

            var pickUpPoint = await _context.PickUpPoints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pickUpPoint == null)
            {
                return NotFound();
            }

            return View(pickUpPoint);
        }

        // POST: PickUpPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PickUpPoints == null)
            {
                return Problem("Entity set 'MarketDbContext.PickUpPoints'  is null.");
            }
            var pickUpPoint = await _context.PickUpPoints.FindAsync(id);
            if (pickUpPoint != null)
            {
                _context.PickUpPoints.Remove(pickUpPoint);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PickUpPointExists(int id)
        {
          return (_context.PickUpPoints?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
