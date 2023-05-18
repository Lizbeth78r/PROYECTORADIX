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
    public class TipodocumentoesController : Controller
    {
        private readonly Radix1Context _context;

        public TipodocumentoesController(Radix1Context context)
        {
            _context = context;
        }

        // GET: Tipodocumentoes
        public async Task<IActionResult> Index()
        {
              return _context.Tipodocumentos != null ? 
                          View(await _context.Tipodocumentos.ToListAsync()) :
                          Problem("Entity set 'Radix1Context.Tipodocumentos'  is null.");
        }

        // GET: Tipodocumentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tipodocumentos == null)
            {
                return NotFound();
            }

            var tipodocumento = await _context.Tipodocumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipodocumento == null)
            {
                return NotFound();
            }

            return View(tipodocumento);
        }

        // GET: Tipodocumentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipodocumentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado")] Tipodocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipodocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipodocumento);
        }

        // GET: Tipodocumentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tipodocumentos == null)
            {
                return NotFound();
            }

            var tipodocumento = await _context.Tipodocumentos.FindAsync(id);
            if (tipodocumento == null)
            {
                return NotFound();
            }
            return View(tipodocumento);
        }

        // POST: Tipodocumentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado")] Tipodocumento tipodocumento)
        {
            if (id != tipodocumento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipodocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipodocumentoExists(tipodocumento.Id))
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
            return View(tipodocumento);
        }

        // GET: Tipodocumentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tipodocumentos == null)
            {
                return NotFound();
            }

            var tipodocumento = await _context.Tipodocumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipodocumento == null)
            {
                return NotFound();
            }

            return View(tipodocumento);
        }

        // POST: Tipodocumentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tipodocumentos == null)
            {
                return Problem("Entity set 'Radix1Context.Tipodocumentos'  is null.");
            }
            var tipodocumento = await _context.Tipodocumentos.FindAsync(id);
            if (tipodocumento != null)
            {
                _context.Tipodocumentos.Remove(tipodocumento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipodocumentoExists(int id)
        {
          return (_context.Tipodocumentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
