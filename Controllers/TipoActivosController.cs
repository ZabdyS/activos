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
    public class TipoActivosController : Controller
    {
        private readonly MyDbContext _context;

        public TipoActivosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: TipoActivos
        public async Task<IActionResult> Index()
        {
              return _context.TipoActivos != null ? 
                          View(await _context.TipoActivos.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.TipoActivos'  is null.");
        }

        // GET: TipoActivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoActivos == null)
            {
                return NotFound();
            }

            var tipoActivo = await _context.TipoActivos
                .FirstOrDefaultAsync(m => m.Id_tipo_activo == id);
            if (tipoActivo == null)
            {
                return NotFound();
            }

            return View(tipoActivo);
        }

        // GET: TipoActivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoActivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_tipo_activo,Descripcion,CuentaContableCompra,CuentaContableDepreciacion,Estado")] TipoActivo tipoActivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoActivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoActivo);
        }

        // GET: TipoActivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoActivos == null)
            {
                return NotFound();
            }

            var tipoActivo = await _context.TipoActivos.FindAsync(id);
            if (tipoActivo == null)
            {
                return NotFound();
            }
            return View(tipoActivo);
        }

        // POST: TipoActivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_tipo_activo,Descripcion,CuentaContableCompra,CuentaContableDepreciacion,Estado")] TipoActivo tipoActivo)
        {
            if (id != tipoActivo.Id_tipo_activo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoActivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoActivoExists(tipoActivo.Id_tipo_activo))
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
            return View(tipoActivo);
        }

        // GET: TipoActivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoActivos == null)
            {
                return NotFound();
            }

            var tipoActivo = await _context.TipoActivos
                .FirstOrDefaultAsync(m => m.Id_tipo_activo == id);
            if (tipoActivo == null)
            {
                return NotFound();
            }

            return View(tipoActivo);
        }

        // POST: TipoActivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoActivos == null)
            {
                return Problem("Entity set 'MyDbContext.TipoActivos'  is null.");
            }
            var tipoActivo = await _context.TipoActivos.FindAsync(id);
            if (tipoActivo != null)
            {
                _context.TipoActivos.Remove(tipoActivo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoActivoExists(int id)
        {
          return (_context.TipoActivos?.Any(e => e.Id_tipo_activo == id)).GetValueOrDefault();
        }
    }
}
