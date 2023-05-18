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
    public class ModalidadsController : Controller
    {
        private readonly Radix1Context _context;

        public ModalidadsController(Radix1Context context)
        {
            _context = context;
        }

        // GET: Modalidads
        public async Task<IActionResult> Index()
        {
              return _context.Modalidads != null ? 
                          View(await _context.Modalidads.ToListAsync()) :
                          Problem("Entity set 'Radix1Context.Modalidads'  is null.");
        }

        // GET: Modalidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modalidads == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modalidad == null)
            {
                return NotFound();
            }

            return View(modalidad);
        }

        // GET: Modalidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modalidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado")] Modalidad modalidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modalidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modalidad);
        }

        // GET: Modalidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modalidads == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidads.FindAsync(id);
            if (modalidad == null)
            {
                return NotFound();
            }
            return View(modalidad);
        }

        // POST: Modalidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado")] Modalidad modalidad)
        {
            if (id != modalidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modalidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModalidadExists(modalidad.Id))
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
            return View(modalidad);
        }

        // GET: Modalidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modalidads == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modalidad == null)
            {
                return NotFound();
            }

            return View(modalidad);
        }

        // POST: Modalidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modalidads == null)
            {
                return Problem("Entity set 'Radix1Context.Modalidads'  is null.");
            }
            var modalidad = await _context.Modalidads.FindAsync(id);
            if (modalidad != null)
            {
                _context.Modalidads.Remove(modalidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModalidadExists(int id)
        {
          return (_context.Modalidads?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
