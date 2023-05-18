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
    public class ProyectoesController : Controller
    {
        private readonly Radix1Context _context;

        public ProyectoesController(Radix1Context context)
        {
            _context = context;
        }

        // GET: Proyectoes
        public async Task<IActionResult> Index()
        {
            var radix1Context = _context.Proyectos.Include(p => p.IdProgramaNavigation);
            return View(await radix1Context.ToListAsync());
        }

        // GET: Proyectoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .Include(p => p.IdProgramaNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // GET: Proyectoes/Create
        public IActionResult Create()
        {
            ViewData["IdPrograma"] = new SelectList(_context.Programas, "Id", "Id");
            return View();
        }

        // POST: Proyectoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nombre,IdPrograma,Estado")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPrograma"] = new SelectList(_context.Programas, "Id", "Id", proyecto.IdPrograma);
            return View(proyecto);
        }

        // GET: Proyectoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            ViewData["IdPrograma"] = new SelectList(_context.Programas, "Id", "Id", proyecto.IdPrograma);
            return View(proyecto);
        }

        // POST: Proyectoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Nombre,IdPrograma,Estado")] Proyecto proyecto)
        {
            if (id != proyecto.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProyectoExists(proyecto.Codigo))
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
            ViewData["IdPrograma"] = new SelectList(_context.Programas, "Id", "Id", proyecto.IdPrograma);
            return View(proyecto);
        }

        // GET: Proyectoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .Include(p => p.IdProgramaNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // POST: Proyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proyectos == null)
            {
                return Problem("Entity set 'Radix1Context.Proyectos'  is null.");
            }
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyectoExists(int id)
        {
          return (_context.Proyectos?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
