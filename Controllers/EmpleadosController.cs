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
    public class EmpleadosController : Controller
    {
        private readonly MyDbContext _context;

        public EmpleadosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.empleado.Include(e => e.Departamento).Include(e => e.Tipo);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.empleado
                .Include(e => e.Departamento)
                .Include(e => e.Tipo)
                .FirstOrDefaultAsync(m => m.Id_empleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["Id_departamento"] = new SelectList(_context.departamentos, "Id_departamento", "Descripcion");
            ViewData["Id_tipo"] = new SelectList(_context.tipo, "Id_tipo", "Tipo_persona");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_empleado,Nombre,Cedula,Id_departamento,Id_tipo,FechaIngreso,Estado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_departamento"] = new SelectList(_context.departamentos, "Id_departamento", "Descripcion", empleado.Id_departamento);
            ViewData["Id_tipo"] = new SelectList(_context.tipo, "Id_tipo", "Tipo_persona", empleado.Id_tipo);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["Id_departamento"] = new SelectList(_context.departamentos, "Id_departamento", "Descripcion", empleado.Id_departamento);
            ViewData["Id_tipo"] = new SelectList(_context.tipo, "Id_tipo", "Tipo_persona", empleado.Id_tipo);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_empleado,Nombre,Cedula,Id_departamento,Id_tipo,FechaIngreso,Estado")] Empleado empleado)
        {
            if (id != empleado.Id_empleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id_empleado))
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
            ViewData["Id_departamento"] = new SelectList(_context.departamentos, "Id_departamento", "Descripcion", empleado.Id_departamento);
            ViewData["Id_tipo"] = new SelectList(_context.tipo, "Id_tipo", "Tipo_persona", empleado.Id_tipo);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.empleado
                .Include(e => e.Departamento)
                .Include(e => e.Tipo)
                .FirstOrDefaultAsync(m => m.Id_empleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.empleado == null)
            {
                return Problem("Entity set 'MyDbContext.empleado'  is null.");
            }
            var empleado = await _context.empleado.FindAsync(id);
            if (empleado != null)
            {
                _context.empleado.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return (_context.empleado?.Any(e => e.Id_empleado == id)).GetValueOrDefault();
        }
    }
}
