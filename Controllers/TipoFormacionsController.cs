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
    public class TipoFormacionsController : Controller
    {
        private readonly Radix1Context _context;

        public TipoFormacionsController(Radix1Context context)
        {
            _context = context;
        }

        // GET: TipoFormacions
        public async Task<IActionResult> Index()
        {
              return _context.TipoFormacions != null ? 
                          View(await _context.TipoFormacions.ToListAsync()) :
                          Problem("Entity set 'Radix1Context.TipoFormacions'  is null.");
        }

        // GET: TipoFormacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoFormacions == null)
            {
                return NotFound();
            }

            var tipoFormacion = await _context.TipoFormacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoFormacion == null)
            {
                return NotFound();
            }

            return View(tipoFormacion);
        }

        // GET: TipoFormacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoFormacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado")] TipoFormacion tipoFormacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoFormacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoFormacion);
        }

        // GET: TipoFormacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoFormacions == null)
            {
                return NotFound();
            }

            var tipoFormacion = await _context.TipoFormacions.FindAsync(id);
            if (tipoFormacion == null)
            {
                return NotFound();
            }
            return View(tipoFormacion);
        }

        // POST: TipoFormacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado")] TipoFormacion tipoFormacion)
        {
            if (id != tipoFormacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoFormacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoFormacionExists(tipoFormacion.Id))
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
            return View(tipoFormacion);
        }

        // GET: TipoFormacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoFormacions == null)
            {
                return NotFound();
            }

            var tipoFormacion = await _context.TipoFormacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoFormacion == null)
            {
                return NotFound();
            }

            return View(tipoFormacion);
        }

        // POST: TipoFormacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoFormacions == null)
            {
                return Problem("Entity set 'Radix1Context.TipoFormacions'  is null.");
            }
            var tipoFormacion = await _context.TipoFormacions.FindAsync(id);
            if (tipoFormacion != null)
            {
                _context.TipoFormacions.Remove(tipoFormacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoFormacionExists(int id)
        {
          return (_context.TipoFormacions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
