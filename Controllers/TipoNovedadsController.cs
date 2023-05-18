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
    public class TipoNovedadsController : Controller
    {
        private readonly Radix1Context _context;

        public TipoNovedadsController(Radix1Context context)
        {
            _context = context;
        }

        // GET: TipoNovedads
        public async Task<IActionResult> Index()
        {
              return _context.TipoNovedads != null ? 
                          View(await _context.TipoNovedads.ToListAsync()) :
                          Problem("Entity set 'Radix1Context.TipoNovedads'  is null.");
        }

        // GET: TipoNovedads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoNovedads == null)
            {
                return NotFound();
            }

            var tipoNovedad = await _context.TipoNovedads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoNovedad == null)
            {
                return NotFound();
            }

            return View(tipoNovedad);
        }

        // GET: TipoNovedads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoNovedads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado")] TipoNovedad tipoNovedad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoNovedad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoNovedad);
        }

        // GET: TipoNovedads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoNovedads == null)
            {
                return NotFound();
            }

            var tipoNovedad = await _context.TipoNovedads.FindAsync(id);
            if (tipoNovedad == null)
            {
                return NotFound();
            }
            return View(tipoNovedad);
        }

        // POST: TipoNovedads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado")] TipoNovedad tipoNovedad)
        {
            if (id != tipoNovedad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoNovedad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoNovedadExists(tipoNovedad.Id))
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
            return View(tipoNovedad);
        }

        // GET: TipoNovedads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoNovedads == null)
            {
                return NotFound();
            }

            var tipoNovedad = await _context.TipoNovedads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoNovedad == null)
            {
                return NotFound();
            }

            return View(tipoNovedad);
        }

        // POST: TipoNovedads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoNovedads == null)
            {
                return Problem("Entity set 'Radix1Context.TipoNovedads'  is null.");
            }
            var tipoNovedad = await _context.TipoNovedads.FindAsync(id);
            if (tipoNovedad != null)
            {
                _context.TipoNovedads.Remove(tipoNovedad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoNovedadExists(int id)
        {
          return (_context.TipoNovedads?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
