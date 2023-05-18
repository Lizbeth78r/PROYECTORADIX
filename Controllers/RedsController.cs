using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROYECTORADIX.Models;

namespace PROYECTORADIX.Controllers
{
    public class RedsController : Controller
    {
        private readonly Radix1Context _context;

        public RedsController(Radix1Context context)
        {
            _context = context;
        }

        // GET: Reds
        public async Task<IActionResult> Index()
        {
            var radix1Context = _context.Reds.Include(r => r.IdAreaNavigation);
            return View(await radix1Context.ToListAsync());
        }

        // GET: Reds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reds == null)
            {
                return NotFound();
            }

            var red = await _context.Reds
                .Include(r => r.IdAreaNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (red == null)
            {
                return NotFound();
            }

            return View(red);
        }

        // GET: Reds/Create
        public IActionResult Create()
        {
            ViewData["IdArea"] = new SelectList(_context.Areas, "Codigo", "Nombre");
            return View();
        }

        // POST: Reds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nombre,IdArea,Estado")] Red red)
        {
            if (ModelState.IsValid)
            {
                _context.Add(red);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArea"] = new SelectList(_context.Areas, "Codigo", "Nombre", red.IdArea);
            return View(red);
        }

        // GET: Reds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reds == null)
            {
                return NotFound();
            }

            var red = await _context.Reds.FindAsync(id);
            if (red == null)
            {
                return NotFound();
            }
            ViewData["IdArea"] = new SelectList(_context.Areas, "Codigo", "Nombre", red.IdArea);
            return View(red);
        }

        // POST: Reds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Nombre,IdArea,Estado")] Red red)
        {
            if (id != red.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(red);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RedExists(red.Codigo))
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
            ViewData["IdArea"] = new SelectList(_context.Areas, "Codigo", "Nombre", red.IdArea);
            return View(red);
        }

        // GET: Reds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reds == null)
            {
                return NotFound();
            }

            var red = await _context.Reds
                .Include(r => r.IdAreaNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (red == null)
            {
                return NotFound();
            }

            return View(red);
        }

        // POST: Reds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reds == null)
            {
                return Problem("Entity set 'Radix1Context.Reds'  is null.");
            }
            var red = await _context.Reds.FindAsync(id);
            if (red != null)
            {
                _context.Reds.Remove(red);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RedExists(int id)
        {
          return (_context.Reds?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
