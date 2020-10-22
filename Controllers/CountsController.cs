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
    public class CountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Counts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Counts.ToListAsync());
        }

        // GET: Counts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var count = await _context.Counts
                .FirstOrDefaultAsync(m => m.CountId == id);
            if (count == null)
            {
                return NotFound();
            }

            return View(count);
        }

        // GET: Counts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Counts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountId,ManagerId,userNumber,departName,countTotal")] Count count)
        {
            if (ModelState.IsValid)
            {
                _context.Add(count);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(count);
        }

        // GET: Counts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var count = await _context.Counts.FindAsync(id);
            if (count == null)
            {
                return NotFound();
            }
            return View(count);
        }

        // POST: Counts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountId,ManagerId,userNumber,departName,countTotal")] Count count)
        {
            if (id != count.CountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(count);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountExists(count.CountId))
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
            return View(count);
        }

        // GET: Counts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var count = await _context.Counts
                .FirstOrDefaultAsync(m => m.CountId == id);
            if (count == null)
            {
                return NotFound();
            }

            return View(count);
        }

        // POST: Counts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var count = await _context.Counts.FindAsync(id);
            _context.Counts.Remove(count);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountExists(int id)
        {
            return _context.Counts.Any(e => e.CountId == id);
        }
    }
}
