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
    public class ActivoFijosController : Controller
    {
        private readonly MyDbContext _context;

        public ActivoFijosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ActivoFijos
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.ActivosFijos.Include(a => a.Departamento).Include(a => a.TipoActivo);
            return View(await myDbContext.ToListAsync());
        }

        // GET: ActivoFijos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ActivosFijos == null)
            {
                return NotFound();
            }

            var activoFijo = await _context.ActivosFijos
                .Include(a => a.Departamento)
                .Include(a => a.TipoActivo)
                .FirstOrDefaultAsync(m => m.Id_activo_fijo == id);
            if (activoFijo == null)
            {
                return NotFound();
            }

            return View(activoFijo);
        }

        // GET: ActivoFijos/Create
        public IActionResult Create()
        {
            ViewData["Id_departamento"] = new SelectList(_context.departamentos, "Id_departamento", "Descripcion");
            ViewData["Id_tipo_activo"] = new SelectList(_context.TipoActivos, "Id_tipo_activo", "Descripcion");
            return View();
        }

        // POST: ActivoFijos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_activo_fijo,Descripcion,Id_departamento,Id_tipo_activo,FechaRegistro,ValorCompra,DepreciacionAcumulada,Estado")] ActivoFijo activoFijo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activoFijo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_departamento"] = new SelectList(_context.departamentos, "Id_departamento", "Descripcion", activoFijo.Id_departamento);
            ViewData["Id_tipo_activo"] = new SelectList(_context.TipoActivos, "Id_tipo_activo", "Descripcion", activoFijo.Id_tipo_activo);
            return View(activoFijo);
        }

        // GET: ActivoFijos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ActivosFijos == null)
            {
                return NotFound();
            }

            var activoFijo = await _context.ActivosFijos.FindAsync(id);
            if (activoFijo == null)
            {
                return NotFound();
            }
            ViewData["Id_departamento"] = new SelectList(_context.departamentos, "Id_departamento", "Descripcion", activoFijo.Id_departamento);
            ViewData["Id_tipo_activo"] = new SelectList(_context.TipoActivos, "Id_tipo_activo", "Descripcion", activoFijo.Id_tipo_activo);
            return View(activoFijo);
        }

        // POST: ActivoFijos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_activo_fijo,Descripcion,Id_departamento,Id_tipo_activo,FechaRegistro,ValorCompra,DepreciacionAcumulada,Estado")] ActivoFijo activoFijo)
        {
            if (id != activoFijo.Id_activo_fijo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activoFijo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivoFijoExists(activoFijo.Id_activo_fijo))
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
            ViewData["Id_departamento"] = new SelectList(_context.departamentos, "Id_departamento", "Descripcion", activoFijo.Id_departamento);
            ViewData["Id_tipo_activo"] = new SelectList(_context.TipoActivos, "Id_tipo_activo", "Descripcion", activoFijo.Id_tipo_activo);
            return View(activoFijo);
        }

        // GET: ActivoFijos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ActivosFijos == null)
            {
                return NotFound();
            }

            var activoFijo = await _context.ActivosFijos
                .Include(a => a.Departamento)
                .Include(a => a.TipoActivo)
                .FirstOrDefaultAsync(m => m.Id_activo_fijo == id);
            if (activoFijo == null)
            {
                return NotFound();
            }

            return View(activoFijo);
        }

        // POST: ActivoFijos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ActivosFijos == null)
            {
                return Problem("Entity set 'MyDbContext.ActivosFijos'  is null.");
            }
            var activoFijo = await _context.ActivosFijos.FindAsync(id);
            if (activoFijo != null)
            {
                _context.ActivosFijos.Remove(activoFijo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivoFijoExists(int id)
        {
          return (_context.ActivosFijos?.Any(e => e.Id_activo_fijo == id)).GetValueOrDefault();
        }
    }
}
