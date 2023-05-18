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
    public class CompetenciumsController : Controller
    {
        private readonly Radix1Context _context;

        public CompetenciumsController(Radix1Context context)
        {
            _context = context;
        }

        // GET: Competenciums
        public async Task<IActionResult> Index()
        {
            var radix1Context = _context.Competencia.Include(c => c.IdResultadoAprenNavigation);
            return View(await radix1Context.ToListAsync());
        }

        // GET: Competenciums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Competencia == null)
            {
                return NotFound();
            }

            var competencium = await _context.Competencia
                .Include(c => c.IdResultadoAprenNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (competencium == null)
            {
                return NotFound();
            }

            return View(competencium);
        }

        // GET: Competenciums/Create
        public IActionResult Create()
        {
            ViewData["IdResultadoApren"] = new SelectList(_context.Resultadoaprendizajes, "Codigo", "Codigo");
            return View();
        }

        // POST: Competenciums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nombre,Duracion,IdResultadoApren,Estado")] Competencium competencium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competencium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdResultadoApren"] = new SelectList(_context.Resultadoaprendizajes, "Codigo", "Codigo", competencium.IdResultadoApren);
            return View(competencium);
        }

        // GET: Competenciums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Competencia == null)
            {
                return NotFound();
            }

            var competencium = await _context.Competencia.FindAsync(id);
            if (competencium == null)
            {
                return NotFound();
            }
            ViewData["IdResultadoApren"] = new SelectList(_context.Resultadoaprendizajes, "Codigo", "Codigo", competencium.IdResultadoApren);
            return View(competencium);
        }

        // POST: Competenciums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Nombre,Duracion,IdResultadoApren,Estado")] Competencium competencium)
        {
            if (id != competencium.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competencium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetenciumExists(competencium.Codigo))
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
            ViewData["IdResultadoApren"] = new SelectList(_context.Resultadoaprendizajes, "Codigo", "Codigo", competencium.IdResultadoApren);
            return View(competencium);
        }

        // GET: Competenciums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Competencia == null)
            {
                return NotFound();
            }

            var competencium = await _context.Competencia
                .Include(c => c.IdResultadoAprenNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (competencium == null)
            {
                return NotFound();
            }

            return View(competencium);
        }

        // POST: Competenciums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Competencia == null)
            {
                return Problem("Entity set 'Radix1Context.Competencia'  is null.");
            }
            var competencium = await _context.Competencia.FindAsync(id);
            if (competencium != null)
            {
                _context.Competencia.Remove(competencium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenciumExists(int id)
        {
          return (_context.Competencia?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
