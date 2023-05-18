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
    public class NovedadsController : Controller
    {
        private readonly Radix1Context _context;

        public NovedadsController(Radix1Context context)
        {
            _context = context;
        }

        // GET: Novedads
        public async Task<IActionResult> Index()
        {
            var radix1Context = _context.Novedads.Include(n => n.IdAprendizNavigation).Include(n => n.IdTipoNovedadNavigation).Include(n => n.IdUsuarioNavigation);
            return View(await radix1Context.ToListAsync());
        }

        // GET: Novedads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Novedads == null)
            {
                return NotFound();
            }

            var novedad = await _context.Novedads
                .Include(n => n.IdAprendizNavigation)
                .Include(n => n.IdTipoNovedadNavigation)
                .Include(n => n.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (novedad == null)
            {
                return NotFound();
            }

            return View(novedad);
        }

        // GET: Novedads/Create
        public IActionResult Create()
        {
            ViewData["IdAprendiz"] = new SelectList(_context.Aprendizs, "NumeroId", "NumeroId");
            ViewData["IdTipoNovedad"] = new SelectList(_context.TipoNovedads, "Id", "Id");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "NumeroId", "NumeroId");
            return View();
        }

        // POST: Novedads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAprendiz,IdUsuario,IdTipoNovedad,FechaInicio,Estado")] Novedad novedad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novedad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAprendiz"] = new SelectList(_context.Aprendizs, "NumeroId", "NumeroId", novedad.IdAprendiz);
            ViewData["IdTipoNovedad"] = new SelectList(_context.TipoNovedads, "Id", "Id", novedad.IdTipoNovedad);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "NumeroId", "NumeroId", novedad.IdUsuario);
            return View(novedad);
        }

        // GET: Novedads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Novedads == null)
            {
                return NotFound();
            }

            var novedad = await _context.Novedads.FindAsync(id);
            if (novedad == null)
            {
                return NotFound();
            }
            ViewData["IdAprendiz"] = new SelectList(_context.Aprendizs, "NumeroId", "NumeroId", novedad.IdAprendiz);
            ViewData["IdTipoNovedad"] = new SelectList(_context.TipoNovedads, "Id", "Id", novedad.IdTipoNovedad);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "NumeroId", "NumeroId", novedad.IdUsuario);
            return View(novedad);
        }

        // POST: Novedads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAprendiz,IdUsuario,IdTipoNovedad,FechaInicio,Estado")] Novedad novedad)
        {
            if (id != novedad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novedad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovedadExists(novedad.Id))
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
            ViewData["IdAprendiz"] = new SelectList(_context.Aprendizs, "NumeroId", "NumeroId", novedad.IdAprendiz);
            ViewData["IdTipoNovedad"] = new SelectList(_context.TipoNovedads, "Id", "Id", novedad.IdTipoNovedad);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "NumeroId", "NumeroId", novedad.IdUsuario);
            return View(novedad);
        }

        // GET: Novedads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Novedads == null)
            {
                return NotFound();
            }

            var novedad = await _context.Novedads
                .Include(n => n.IdAprendizNavigation)
                .Include(n => n.IdTipoNovedadNavigation)
                .Include(n => n.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (novedad == null)
            {
                return NotFound();
            }

            return View(novedad);
        }

        // POST: Novedads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Novedads == null)
            {
                return Problem("Entity set 'Radix1Context.Novedads'  is null.");
            }
            var novedad = await _context.Novedads.FindAsync(id);
            if (novedad != null)
            {
                _context.Novedads.Remove(novedad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovedadExists(int id)
        {
          return (_context.Novedads?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
