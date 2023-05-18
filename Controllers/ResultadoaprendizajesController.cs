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
    public class ResultadoaprendizajesController : Controller
    {
        private readonly Radix1Context _context;

        public ResultadoaprendizajesController(Radix1Context context)
        {
            _context = context;
        }

        // GET: Resultadoaprendizajes
        public async Task<IActionResult> Index()
        {
              return _context.Resultadoaprendizajes != null ? 
                          View(await _context.Resultadoaprendizajes.ToListAsync()) :
                          Problem("Entity set 'Radix1Context.Resultadoaprendizajes'  is null.");
        }

        // GET: Resultadoaprendizajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resultadoaprendizajes == null)
            {
                return NotFound();
            }

            var resultadoaprendizaje = await _context.Resultadoaprendizajes
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (resultadoaprendizaje == null)
            {
                return NotFound();
            }

            return View(resultadoaprendizaje);
        }

        // GET: Resultadoaprendizajes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resultadoaprendizajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Descripcion,Estado")] Resultadoaprendizaje resultadoaprendizaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultadoaprendizaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resultadoaprendizaje);
        }

        // GET: Resultadoaprendizajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resultadoaprendizajes == null)
            {
                return NotFound();
            }

            var resultadoaprendizaje = await _context.Resultadoaprendizajes.FindAsync(id);
            if (resultadoaprendizaje == null)
            {
                return NotFound();
            }
            return View(resultadoaprendizaje);
        }

        // POST: Resultadoaprendizajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Descripcion,Estado")] Resultadoaprendizaje resultadoaprendizaje)
        {
            if (id != resultadoaprendizaje.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultadoaprendizaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultadoaprendizajeExists(resultadoaprendizaje.Codigo))
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
            return View(resultadoaprendizaje);
        }

        // GET: Resultadoaprendizajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resultadoaprendizajes == null)
            {
                return NotFound();
            }

            var resultadoaprendizaje = await _context.Resultadoaprendizajes
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (resultadoaprendizaje == null)
            {
                return NotFound();
            }

            return View(resultadoaprendizaje);
        }

        // POST: Resultadoaprendizajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Resultadoaprendizajes == null)
            {
                return Problem("Entity set 'Radix1Context.Resultadoaprendizajes'  is null.");
            }
            var resultadoaprendizaje = await _context.Resultadoaprendizajes.FindAsync(id);
            if (resultadoaprendizaje != null)
            {
                _context.Resultadoaprendizajes.Remove(resultadoaprendizaje);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultadoaprendizajeExists(int id)
        {
          return (_context.Resultadoaprendizajes?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
