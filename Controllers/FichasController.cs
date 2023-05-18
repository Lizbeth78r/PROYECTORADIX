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
    public class FichasController : Controller
    {
        private readonly Radix1Context _context;

        public FichasController(Radix1Context context)
        {
            _context = context;
        }

        // GET: Fichas
        public async Task<IActionResult> Index()
        {
            var radix1Context = _context.Fichas.Include(f => f.IdJornadaNavigation).Include(f => f.IdModalidadNavigation).Include(f => f.IdProgramaNavigation).Include(f => f.IdTipoFormacionNavigation);
            return View(await radix1Context.ToListAsync());
        }

        // GET: Fichas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fichas == null)
            {
                return NotFound();
            }

            var ficha = await _context.Fichas
                .Include(f => f.IdJornadaNavigation)
                .Include(f => f.IdModalidadNavigation)
                .Include(f => f.IdProgramaNavigation)
                .Include(f => f.IdTipoFormacionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ficha == null)
            {
                return NotFound();
            }

            return View(ficha);
        }

        // GET: Fichas/Create
        public IActionResult Create()
        {
            ViewData["IdJornada"] = new SelectList(_context.Jornada, "Id", "Id");
            ViewData["IdModalidad"] = new SelectList(_context.Modalidads, "Id", "Id");
            ViewData["IdPrograma"] = new SelectList(_context.Programas, "Id", "Id");
            ViewData["IdTipoFormacion"] = new SelectList(_context.TipoFormacions, "Id", "Id");
            return View();
        }

        // POST: Fichas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPrograma,IdJornada,IdTipoFormacion,IdModalidad,FechaIniciolectiva,FechaFinallectiva,FechaIniciopractica,FechaFinalpractica,IdInstructorlider,Estado")] Ficha ficha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ficha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJornada"] = new SelectList(_context.Jornada, "Id", "Id", ficha.IdJornada);
            ViewData["IdModalidad"] = new SelectList(_context.Modalidads, "Id", "Id", ficha.IdModalidad);
            ViewData["IdPrograma"] = new SelectList(_context.Programas, "Id", "Id", ficha.IdPrograma);
            ViewData["IdTipoFormacion"] = new SelectList(_context.TipoFormacions, "Id", "Id", ficha.IdTipoFormacion);
            return View(ficha);
        }

        // GET: Fichas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fichas == null)
            {
                return NotFound();
            }

            var ficha = await _context.Fichas.FindAsync(id);
            if (ficha == null)
            {
                return NotFound();
            }
            ViewData["IdJornada"] = new SelectList(_context.Jornada, "Id", "Id", ficha.IdJornada);
            ViewData["IdModalidad"] = new SelectList(_context.Modalidads, "Id", "Id", ficha.IdModalidad);
            ViewData["IdPrograma"] = new SelectList(_context.Programas, "Id", "Id", ficha.IdPrograma);
            ViewData["IdTipoFormacion"] = new SelectList(_context.TipoFormacions, "Id", "Id", ficha.IdTipoFormacion);
            return View(ficha);
        }

        // POST: Fichas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPrograma,IdJornada,IdTipoFormacion,IdModalidad,FechaIniciolectiva,FechaFinallectiva,FechaIniciopractica,FechaFinalpractica,IdInstructorlider,Estado")] Ficha ficha)
        {
            if (id != ficha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ficha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FichaExists(ficha.Id))
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
            ViewData["IdJornada"] = new SelectList(_context.Jornada, "Id", "Id", ficha.IdJornada);
            ViewData["IdModalidad"] = new SelectList(_context.Modalidads, "Id", "Id", ficha.IdModalidad);
            ViewData["IdPrograma"] = new SelectList(_context.Programas, "Id", "Id", ficha.IdPrograma);
            ViewData["IdTipoFormacion"] = new SelectList(_context.TipoFormacions, "Id", "Id", ficha.IdTipoFormacion);
            return View(ficha);
        }

        // GET: Fichas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fichas == null)
            {
                return NotFound();
            }

            var ficha = await _context.Fichas
                .Include(f => f.IdJornadaNavigation)
                .Include(f => f.IdModalidadNavigation)
                .Include(f => f.IdProgramaNavigation)
                .Include(f => f.IdTipoFormacionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ficha == null)
            {
                return NotFound();
            }

            return View(ficha);
        }

        // POST: Fichas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fichas == null)
            {
                return Problem("Entity set 'Radix1Context.Fichas'  is null.");
            }
            var ficha = await _context.Fichas.FindAsync(id);
            if (ficha != null)
            {
                _context.Fichas.Remove(ficha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FichaExists(int id)
        {
          return (_context.Fichas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
