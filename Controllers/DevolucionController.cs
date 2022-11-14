using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using integradora555.Models;

namespace integradora555.Controllers
{
    public class DevolucionController : Controller
    {
        private readonly integradora555Context _context;

        public DevolucionController(integradora555Context context)
        {
            _context = context;
        }

        // GET: Devolucion
        public async Task<IActionResult> Index()
        {
            var integradora555Context = _context.Devolucion.Include(d => d.Casa).Include(d => d.Cliente);
            return View(await integradora555Context.ToListAsync());
        }

        // GET: Devolucion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Devolucion == null)
            {
                return NotFound();
            }

            var devolucion = await _context.Devolucion
                .Include(d => d.Casa)
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.DevolucionId == id);
            if (devolucion == null)
            {
                return NotFound();
            }

            return View(devolucion);
        }

        // GET: Devolucion/Create
        public IActionResult Create()
        {
            ViewData["CasaId"] = new SelectList(_context.Casa, "CasaId", "NombreDeCasa");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "clienteId", "Apellido");
            return View();
        }

        // POST: Devolucion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DevolucionId,FechaDevolucion,AlqulerId,ClienteId,CasaId,ClienteNombre,CasaNombre")] Devolucion devolucion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devolucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CasaId"] = new SelectList(_context.Casa, "CasaId", "NombreDeCasa", devolucion.CasaId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "clienteId", "Apellido", devolucion.ClienteId);
            return View(devolucion);
        }

        // GET: Devolucion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Devolucion == null)
            {
                return NotFound();
            }

            var devolucion = await _context.Devolucion.FindAsync(id);
            if (devolucion == null)
            {
                return NotFound();
            }
            ViewData["CasaId"] = new SelectList(_context.Casa, "CasaId", "NombreDeCasa", devolucion.CasaId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "clienteId", "Apellido", devolucion.ClienteId);
            return View(devolucion);
        }

        // POST: Devolucion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DevolucionId,FechaDevolucion,AlqulerId,ClienteId,CasaId,ClienteNombre,CasaNombre")] Devolucion devolucion)
        {
            if (id != devolucion.DevolucionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devolucion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevolucionExists(devolucion.DevolucionId))
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
            ViewData["CasaId"] = new SelectList(_context.Casa, "CasaId", "NombreDeCasa", devolucion.CasaId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "clienteId", "Apellido", devolucion.ClienteId);
            return View(devolucion);
        }

        // GET: Devolucion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Devolucion == null)
            {
                return NotFound();
            }

            var devolucion = await _context.Devolucion
                .Include(d => d.Casa)
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.DevolucionId == id);
            if (devolucion == null)
            {
                return NotFound();
            }

            return View(devolucion);
        }

        // POST: Devolucion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Devolucion == null)
            {
                return Problem("Entity set 'integradora555Context.Devolucion'  is null.");
            }
            var devolucion = await _context.Devolucion.FindAsync(id);
            if (devolucion != null)
            {
                _context.Devolucion.Remove(devolucion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevolucionExists(int id)
        {
          return (_context.Devolucion?.Any(e => e.DevolucionId == id)).GetValueOrDefault();
        }
    }
}
