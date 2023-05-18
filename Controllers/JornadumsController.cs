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
    public class JornadumsController : Controller
    {
        private readonly Radix1Context _context;

        public JornadumsController(Radix1Context context)
        {
            _context = context;
        }

        // GET: Jornadums
        public async Task<IActionResult> Index()
        {
              return _context.Jornada != null ? 
                          View(await _context.Jornada.ToListAsync()) :
                          Problem("Entity set 'Radix1Context.Jornada'  is null.");
        }

        // GET: Jornadums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jornada == null)
            {
                return NotFound();
            }

            var jornadum = await _context.Jornada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jornadum == null)
            {
                return NotFound();
            }

            return View(jornadum);
        }

        // GET: Jornadums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jornadums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado")] Jornadum jornadum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jornadum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jornadum);
        }

        // GET: Jornadums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jornada == null)
            {
                return NotFound();
            }

            var jornadum = await _context.Jornada.FindAsync(id);
            if (jornadum == null)
            {
                return NotFound();
            }
            return View(jornadum);
        }

        // POST: Jornadums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado")] Jornadum jornadum)
        {
            if (id != jornadum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jornadum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JornadumExists(jornadum.Id))
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
            return View(jornadum);
        }

        // GET: Jornadums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jornada == null)
            {
                return NotFound();
            }

            var jornadum = await _context.Jornada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jornadum == null)
            {
                return NotFound();
            }

            return View(jornadum);
        }

        // POST: Jornadums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jornada == null)
            {
                return Problem("Entity set 'Radix1Context.Jornada'  is null.");
            }
            var jornadum = await _context.Jornada.FindAsync(id);
            if (jornadum != null)
            {
                _context.Jornada.Remove(jornadum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JornadumExists(int id)
        {
          return (_context.Jornada?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
