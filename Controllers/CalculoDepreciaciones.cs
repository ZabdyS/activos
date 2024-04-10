using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using activos.Models;

namespace activos.Controllers
{
    public class CalculoDepreciacionesController : Controller
    {
        private readonly MyDbContext _context;

        public CalculoDepreciacionesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: CalculoDepreciaciones
        public async Task<IActionResult> Index()
        {
            var calculoDepreciaciones = await _context.CalculoDepreciaciones
                .Include(c => c.ActivoFijo)
                .ToListAsync();
            return View(calculoDepreciaciones);
        }

        // GET: CalculoDepreciaciones/Create
        public IActionResult Create()
        {
            ViewData["ActivoFijoId"] = new SelectList(_context.ActivosFijos, "Id_activo_fijo", "Descripcion");
            return View();
        }

        // POST: CalculoDepreciaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnioProceso,MesProceso,ActivoFijoId,FechaProceso,MontoDepreciado,DepreciacionAcumulada,CuentaCompra,CuentaDepreciacion")] CalculoDepreciacion calculoDepreciacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calculoDepreciacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivoFijoId"] = new SelectList(_context.ActivosFijos, "Id_activo_fijo", "Descripcion", calculoDepreciacion.ActivoFijoId);
            return View(calculoDepreciacion);
        }

        // GET: CalculoDepreciaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculoDepreciacion = await _context.CalculoDepreciaciones
                .Include(c => c.ActivoFijo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calculoDepreciacion == null)
            {
                return NotFound();
            }

            return View(calculoDepreciacion);
        }

        // POST: CalculoDepreciaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calculoDepreciacion = await _context.CalculoDepreciaciones.FindAsync(id);
            _context.CalculoDepreciaciones.Remove(calculoDepreciacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: CalculoDepreciaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculoDepreciacion = await _context.CalculoDepreciaciones.FindAsync(id);
            if (calculoDepreciacion == null)
            {
                return NotFound();
            }
            return View(calculoDepreciacion);
        }

        // POST: CalculoDepreciaciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnioProceso,MesProceso,ActivoFijoId,FechaProceso,MontoDepreciado,DepreciacionAcumulada,CuentaCompra,CuentaDepreciacion")] CalculoDepreciacion calculoDepreciacion)
        {
            if (id != calculoDepreciacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calculoDepreciacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalculoDepreciacionExists(calculoDepreciacion.Id))
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
            return View(calculoDepreciacion);
        }

        private bool CalculoDepreciacionExists(int id)
        {
            return _context.CalculoDepreciaciones.Any(e => e.Id == id);
        }
    }
}
