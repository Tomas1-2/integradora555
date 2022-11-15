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
    public class CasaController : Controller
    {
        private readonly integradora555Context _context;

        public CasaController(integradora555Context context)
        {
            _context = context;
        }

        // GET: Casa
        public async Task<IActionResult> Index()
        {
              return _context.Casa != null ? 
                          View(await _context.Casa.ToListAsync()) :
                          Problem("Entity set 'integradora555Context.Casa'  is null.");
        }

        // GET: Casa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Casa == null)
            {
                return NotFound();
            }

            var casa = await _context.Casa
                .FirstOrDefaultAsync(m => m.CasaId == id);
            if (casa == null)
            {
                return NotFound();
            }

            return View(casa);
        }

        // GET: Casa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Casa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CasaId,NombreDeCasa,domicilio,NombreDueño,imagenDeCasa,alquilada,eliminada")] Casa casa, IFormFile imagenDeCasa)
        {
            if(ModelState.IsValid)
            {
                if (imagenDeCasa != null && imagenDeCasa.Length > 0)
                {
                    byte[]? Casaimagen = null;
                    using (var fs1 = imagenDeCasa.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        Casaimagen = ms1.ToArray();
                    }
                    casa.imagenDeCasa = Casaimagen;
                }

                    _context.Add(casa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
            return View(casa);
        }
        

        // GET: Casa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Casa == null)
            {
                return NotFound();
            }

            var casa = await _context.Casa.FindAsync(id);
            if (casa == null)
            {
                return NotFound();
            }
            return View(casa);
        }

        // POST: Casa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CasaId,NombreDeCasa,domicilio,NombreDueño,imagenDeCasa,alquilada,eliminada")] Casa casa)
        {
            if (id != casa.CasaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasaExists(casa.CasaId))
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
            return View(casa);
        }

        // GET: Casa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Casa == null)
            {
                return NotFound();
            }

            var casa = await _context.Casa
                .FirstOrDefaultAsync(m => m.CasaId == id);
            if (casa == null)
            {
                return NotFound();
            }

            return View(casa);
        }

        // POST: Casa/Delete/5
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Casa = await _context.Casa.FindAsync(id);
            if(Casa.alquilada == true){
                return RedirectToAction(nameof(Index));
            }
            if (Casa != null)
            {
                var CasaAlquilada = (from a in _context.Alquiler where a.casaId == id select a).Count();
                if(CasaAlquilada == 0)
                {
                    _context.Casa.Remove(Casa);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Casa.eliminada = true;
                    Casa.NombreDeCasa = Casa.NombreDeCasa + " (Eliminada)";
                    _context.Update(Casa);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CasaExists(int id)
        {
          return (_context.Casa?.Any(e => e.CasaId == id)).GetValueOrDefault();
        }
    }
}
