using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using activos.Models;

namespace activos.Controllers
{
    public class TipoesController : Controller
    {
        private readonly MyDbContext _context;

        public TipoesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Tipoes
        public async Task<IActionResult> Index()
        {
              return _context.tipo != null ? 
                          View(await _context.tipo.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.tipo'  is null.");
        }

        // GET: Tipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tipo == null)
            {
                return NotFound();
            }

            var tipo = await _context.tipo
                .FirstOrDefaultAsync(m => m.Id_tipo == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // GET: Tipoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_tipo,Tipo_persona")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo);
        }

        // GET: Tipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tipo == null)
            {
                return NotFound();
            }

            var tipo = await _context.tipo.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return View(tipo);
        }

        // POST: Tipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_tipo,Tipo_persona")] Tipo tipo)
        {
            if (id != tipo.Id_tipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoExists(tipo.Id_tipo))
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
            return View(tipo);
        }

        // GET: Tipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tipo == null)
            {
                return NotFound();
            }

            var tipo = await _context.tipo
                .FirstOrDefaultAsync(m => m.Id_tipo == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // POST: Tipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tipo == null)
            {
                return Problem("Entity set 'MyDbContext.tipo'  is null.");
            }
            var tipo = await _context.tipo.FindAsync(id);
            if (tipo != null)
            {
                _context.tipo.Remove(tipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoExists(int id)
        {
          return (_context.tipo?.Any(e => e.Id_tipo == id)).GetValueOrDefault();
        }
    }
}
