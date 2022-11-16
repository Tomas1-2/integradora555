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
    public class AlquilerController : Controller
    {
        private readonly integradora555Context _context;

        public AlquilerController(integradora555Context context)
        {
            _context = context;
        }

        // GET: Alquiler
        public async Task<IActionResult> Index()
        {
            var integradora555Context = _context.Alquiler.Include(a => a.Casa).Include(a => a.Cliente);
            return View(await integradora555Context.ToListAsync());
        }

        // GET: Alquiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alquiler == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquiler
                .Include(a => a.Casa)
                .Include(a => a.Cliente)
                .FirstOrDefaultAsync(m => m.AlquilerId == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // GET: Alquiler/Create
         public IActionResult Create()
        {
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "Nombre", "Apellido");
            ViewData["CasaId"] = new SelectList(_context.Casa.Where(x => x.alquilada == false && x.eliminada == false), "CasaId", "NombreDeCasa");
            return View();
        }

        // POST: Alquiler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlquilerId,FechaDeAlquiler,clienteId,casaId,ClienteNombre,CasaNombre")] Alquiler alquiler)
        {
                 if (ModelState.IsValid)
            {
                var Casa = (from a in _context.Casa where a.CasaId == alquiler.casaId select a).SingleOrDefault();
                var Cliente = (from a in _context.Cliente where a.clienteId == alquiler.clienteId select a).SingleOrDefault();
                alquiler.CasaNombre = Casa.NombreDeCasa;
                alquiler.ClienteNombre = Cliente.Nombre + " " + Cliente.Apellido;
                Casa.alquilada = true;
                _context.Add(alquiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "Nombre", "Apellido");
            ViewData["CasaId"] = new SelectList(_context.Casa.Where(x => x.alquilada == false && x.eliminada == false), "CasaId", "NombreDeCasa");
            return View(alquiler);
        }

        // GET: Alquiler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alquiler == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquiler.FindAsync(id);
            if (alquiler == null)
            {
                return NotFound();
            }
            ViewData["casaId"] = new SelectList(_context.Casa, "CasaId", "NombreDeCasa", alquiler.casaId);
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "Apellido", alquiler.clienteId);
            return View(alquiler);
        }

        // POST: Alquiler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlquilerId,FechaDeAlquiler,clienteId,casaId,ClienteNombre,CasaNombre")] Alquiler alquiler)
        {
            if (id != alquiler.AlquilerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlquilerExists(alquiler.AlquilerId))
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
            ViewData["casaId"] = new SelectList(_context.Casa, "CasaId", "NombreDeCasa", alquiler.casaId);
            ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "Apellido", alquiler.clienteId);
            return View(alquiler);
        }

        // GET: Alquiler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alquiler == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquiler
                .Include(a => a.Casa)
                .Include(a => a.Cliente)
                .FirstOrDefaultAsync(m => m.AlquilerId == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // POST: Alquiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alquiler == null)
            {
                return Problem("Entity set 'integradora555Context.Alquiler'  is null.");
            }
            var alquiler = await _context.Alquiler.FindAsync(id);
            if (alquiler != null)
            {
                _context.Alquiler.Remove(alquiler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlquilerExists(int id)
        {
          return (_context.Alquiler?.Any(e => e.AlquilerId == id)).GetValueOrDefault();
        }
    }
}
