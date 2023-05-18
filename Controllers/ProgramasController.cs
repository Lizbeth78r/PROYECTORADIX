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
    public class ProgramasController : Controller
    {
        private readonly Radix1Context _context;

        public ProgramasController(Radix1Context context)
        {
            _context = context;
        }

        // GET: Programas
        public async Task<IActionResult> Index()
        {
            var radix1Context = _context.Programas.Include(p => p.IdRedNavigation).Include(p => p.IdTipodeformacionNavigation);
            return View(await radix1Context.ToListAsync());
        }

        // GET: Programas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Programas == null)
            {
                return NotFound();
            }

            var programa = await _context.Programas
                .Include(p => p.IdRedNavigation)
                .Include(p => p.IdTipodeformacionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programa == null)
            {
                return NotFound();
            }

            return View(programa);
        }

        // GET: Programas/Create
        public IActionResult Create()
        {
            ViewData["IdRed"] = new SelectList(_context.Reds, "Codigo", "Codigo");
            ViewData["IdTipodeformacion"] = new SelectList(_context.TipoFormacions, "Id", "Id");
            return View();
        }

        // POST: Programas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Creditos,VersionPrograma,DuracionLectiva,DuracionProductiva,IdTipodeformacion,Duraciontotal,IdRed,Estado")] Programa programa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRed"] = new SelectList(_context.Reds, "Codigo", "Codigo", programa.IdRed);
            ViewData["IdTipodeformacion"] = new SelectList(_context.TipoFormacions, "Id", "Id", programa.IdTipodeformacion);
            return View(programa);
        }

        // GET: Programas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Programas == null)
            {
                return NotFound();
            }

            var programa = await _context.Programas.FindAsync(id);
            if (programa == null)
            {
                return NotFound();
            }
            ViewData["IdRed"] = new SelectList(_context.Reds, "Codigo", "Codigo", programa.IdRed);
            ViewData["IdTipodeformacion"] = new SelectList(_context.TipoFormacions, "Id", "Id", programa.IdTipodeformacion);
            return View(programa);
        }

        // POST: Programas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Creditos,VersionPrograma,DuracionLectiva,DuracionProductiva,IdTipodeformacion,Duraciontotal,IdRed,Estado")] Programa programa)
        {
            if (id != programa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramaExists(programa.Id))
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
            ViewData["IdRed"] = new SelectList(_context.Reds, "Codigo", "Codigo", programa.IdRed);
            ViewData["IdTipodeformacion"] = new SelectList(_context.TipoFormacions, "Id", "Id", programa.IdTipodeformacion);
            return View(programa);
        }

        // GET: Programas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Programas == null)
            {
                return NotFound();
            }

            var programa = await _context.Programas
                .Include(p => p.IdRedNavigation)
                .Include(p => p.IdTipodeformacionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programa == null)
            {
                return NotFound();
            }

            return View(programa);
        }

        // POST: Programas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Programas == null)
            {
                return Problem("Entity set 'Radix1Context.Programas'  is null.");
            }
            var programa = await _context.Programas.FindAsync(id);
            if (programa != null)
            {
                _context.Programas.Remove(programa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramaExists(int id)
        {
          return (_context.Programas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
