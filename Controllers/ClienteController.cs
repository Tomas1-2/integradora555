using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using integradora555.Models;
using Microsoft.AspNetCore.Authorization;

namespace integradora555.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly integradora555Context _context;

        public ClienteController(integradora555Context context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
              return _context.Cliente != null ? 
                          View(await _context.Cliente.ToListAsync()) :
                          Problem("Entity set 'integradora555Context.Cliente'  is null.");
        }


        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("clienteId,Nombre,Apellido,Dni,FechaDeNacimiento")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("clienteId,Nombre,Apellido,Dni,FechaDeNacimiento")] Cliente cliente)
        {
            if (id != cliente.clienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.clienteId))
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
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.clienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cliente == null)
            {
                return Problem("Entity set 'integradora555Context.Cliente'  is null.");
            }
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                var clienteEnAlquiler = (from a in _context.Alquiler where a.clienteId == id select a).Count();
                if (clienteEnAlquiler == 0)
                _context.Cliente.Remove(cliente);
            
            await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Cliente?.Any(e => e.clienteId == id)).GetValueOrDefault();
        }
    }
}
