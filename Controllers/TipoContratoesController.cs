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
    public class TipoContratoesController : Controller
    {
        private readonly Radix1Context _context;

        public TipoContratoesController(Radix1Context context)
        {
            _context = context;
        }

        // GET: TipoContratoes
        public async Task<IActionResult> Index()
        {
              return _context.TipoContratos != null ? 
                          View(await _context.TipoContratos.ToListAsync()) :
                          Problem("Entity set 'Radix1Context.TipoContratos'  is null.");
        }

        // GET: TipoContratoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoContratos == null)
            {
                return NotFound();
            }

            var tipoContrato = await _context.TipoContratos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoContrato == null)
            {
                return NotFound();
            }

            return View(tipoContrato);
        }

        // GET: TipoContratoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoContratoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado")] TipoContrato tipoContrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoContrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoContrato);
        }

        // GET: TipoContratoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoContratos == null)
            {
                return NotFound();
            }

            var tipoContrato = await _context.TipoContratos.FindAsync(id);
            if (tipoContrato == null)
            {
                return NotFound();
            }
            return View(tipoContrato);
        }

        // POST: TipoContratoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado")] TipoContrato tipoContrato)
        {
            if (id != tipoContrato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoContrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoContratoExists(tipoContrato.Id))
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
            return View(tipoContrato);
        }

        // GET: TipoContratoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoContratos == null)
            {
                return NotFound();
            }

            var tipoContrato = await _context.TipoContratos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoContrato == null)
            {
                return NotFound();
            }

            return View(tipoContrato);
        }

        // POST: TipoContratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoContratos == null)
            {
                return Problem("Entity set 'Radix1Context.TipoContratos'  is null.");
            }
            var tipoContrato = await _context.TipoContratos.FindAsync(id);
            if (tipoContrato != null)
            {
                _context.TipoContratos.Remove(tipoContrato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoContratoExists(int id)
        {
          return (_context.TipoContratos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
