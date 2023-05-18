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
    public class ProgramaCompetenciumsController : Controller
    {
        private readonly Radix1Context _context;

        public ProgramaCompetenciumsController(Radix1Context context)
        {
            _context = context;
        }

        // GET: ProgramaCompetenciums
        public async Task<IActionResult> Index()
        {
            var radix1Context = _context.ProgramaCompetencia.Include(p => p.IdCompetenciaNavigation).Include(p => p.IdProgramaNavigation);
            return View(await radix1Context.ToListAsync());
        }

        // GET: ProgramaCompetenciums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProgramaCompetencia == null)
            {
                return NotFound();
            }

            var programaCompetencium = await _context.ProgramaCompetencia
                .Include(p => p.IdCompetenciaNavigation)
                .Include(p => p.IdProgramaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programaCompetencium == null)
            {
                return NotFound();
            }

            return View(programaCompetencium);
        }

        // GET: ProgramaCompetenciums/Create
        public IActionResult Create()
        {
            ViewData["IdCompetencia"] = new SelectList(_context.Competencia, "Codigo", "Codigo");
            ViewData["IdPrograma"] = new SelectList(_context.Programas, "Id", "Id");
            return View();
        }

        // POST: ProgramaCompetenciums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCompetencia,IdPrograma")] ProgramaCompetencium programaCompetencium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programaCompetencium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCompetencia"] = new SelectList(_context.Competencia, "Codigo", "Codigo", programaCompetencium.IdCompetencia);
            ViewData["IdPrograma"] = new SelectList(_context.Programas, "Id", "Id", programaCompetencium.IdPrograma);
            return View(programaCompetencium);
        }

        // GET: ProgramaCompetenciums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProgramaCompetencia == null)
            {
                return NotFound();
            }

            var programaCompetencium = await _context.ProgramaCompetencia.FindAsync(id);
            if (programaCompetencium == null)
            {
                return NotFound();
            }
            ViewData["IdCompetencia"] = new SelectList(_context.Competencia, "Codigo", "Codigo", programaCompetencium.IdCompetencia);
            ViewData["IdPrograma"] = new SelectList(_context.Programas, "Id", "Id", programaCompetencium.IdPrograma);
            return View(programaCompetencium);
        }

        // POST: ProgramaCompetenciums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCompetencia,IdPrograma")] ProgramaCompetencium programaCompetencium)
        {
            if (id != programaCompetencium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programaCompetencium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramaCompetenciumExists(programaCompetencium.Id))
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
            ViewData["IdCompetencia"] = new SelectList(_context.Competencia, "Codigo", "Codigo", programaCompetencium.IdCompetencia);
            ViewData["IdPrograma"] = new SelectList(_context.Programas, "Id", "Id", programaCompetencium.IdPrograma);
            return View(programaCompetencium);
        }

        // GET: ProgramaCompetenciums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProgramaCompetencia == null)
            {
                return NotFound();
            }

            var programaCompetencium = await _context.ProgramaCompetencia
                .Include(p => p.IdCompetenciaNavigation)
                .Include(p => p.IdProgramaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programaCompetencium == null)
            {
                return NotFound();
            }

            return View(programaCompetencium);
        }

        // POST: ProgramaCompetenciums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProgramaCompetencia == null)
            {
                return Problem("Entity set 'Radix1Context.ProgramaCompetencia'  is null.");
            }
            var programaCompetencium = await _context.ProgramaCompetencia.FindAsync(id);
            if (programaCompetencium != null)
            {
                _context.ProgramaCompetencia.Remove(programaCompetencium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramaCompetenciumExists(int id)
        {
          return (_context.ProgramaCompetencia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
