using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WalmartInventory.Data;
using WalmartInventory.Models;

namespace WalmartInventory.Controllers
{
    public class CountInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CountInformations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.countInformations.Include(c => c.Count).Include(c => c.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CountInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countInformation = await _context.countInformations
                .Include(c => c.Count)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CountInformationId == id);
            if (countInformation == null)
            {
                return NotFound();
            }

            return View(countInformation);
        }

        // GET: CountInformations/Create
        public IActionResult Create()
        {
            ViewData["CountId"] = new SelectList(_context.Counts, "CountId", "CountId");
            ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "ShelfName");
            return View();
        }

        // POST: CountInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountInformationId,ProductId,CountId,Onhand")] CountInformation countInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountId"] = new SelectList(_context.Counts, "CountId", "CountId", countInformation.CountId);
            ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "ShelfName", countInformation.ProductId);
            return View(countInformation);
        }

        // GET: CountInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countInformation = await _context.countInformations.FindAsync(id);
            if (countInformation == null)
            {
                return NotFound();
            }
            ViewData["CountId"] = new SelectList(_context.Counts, "CountId", "CountId", countInformation.CountId);
            ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "ShelfName", countInformation.ProductId);
            return View(countInformation);
        }

        // POST: CountInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountInformationId,ProductId,CountId,Onhand")] CountInformation countInformation)
        {
            if (id != countInformation.CountInformationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountInformationExists(countInformation.CountInformationId))
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
            ViewData["CountId"] = new SelectList(_context.Counts, "CountId", "CountId", countInformation.CountId);
            ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "ShelfName", countInformation.ProductId);
            return View(countInformation);
        }

        // GET: CountInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countInformation = await _context.countInformations
                .Include(c => c.Count)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CountInformationId == id);
            if (countInformation == null)
            {
                return NotFound();
            }

            return View(countInformation);
        }

        // POST: CountInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countInformation = await _context.countInformations.FindAsync(id);
            _context.countInformations.Remove(countInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountInformationExists(int id)
        {
            return _context.countInformations.Any(e => e.CountInformationId == id);
        }
    }
}
