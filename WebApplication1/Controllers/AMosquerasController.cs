using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AMosquerasController : Controller
    {
        private readonly AMosqueraContext _context;

        public AMosquerasController(AMosqueraContext context)
        {
            _context = context;
        }

        // GET: AMosqueras
        public async Task<IActionResult> Index()
        {
            return View(await _context.AMosquera.ToListAsync());
        }

        // GET: AMosqueras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aMosquera = await _context.AMosquera
                .FirstOrDefaultAsync(m => m.edad == id);
            if (aMosquera == null)
            {
                return NotFound();
            }

            return View(aMosquera);
        }

        // GET: AMosqueras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AMosqueras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("edad,numeroFavorito,apodo,genero,fecha")] AMosquera aMosquera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aMosquera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aMosquera);
        }

        // GET: AMosqueras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aMosquera = await _context.AMosquera.FindAsync(id);
            if (aMosquera == null)
            {
                return NotFound();
            }
            return View(aMosquera);
        }

        // POST: AMosqueras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("edad,numeroFavorito,apodo,genero,fecha")] AMosquera aMosquera)
        {
            if (id != aMosquera.edad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aMosquera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AMosqueraExists(aMosquera.edad))
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
            return View(aMosquera);
        }

        // GET: AMosqueras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aMosquera = await _context.AMosquera
                .FirstOrDefaultAsync(m => m.edad == id);
            if (aMosquera == null)
            {
                return NotFound();
            }

            return View(aMosquera);
        }

        // POST: AMosqueras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aMosquera = await _context.AMosquera.FindAsync(id);
            if (aMosquera != null)
            {
                _context.AMosquera.Remove(aMosquera);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AMosqueraExists(int id)
        {
            return _context.AMosquera.Any(e => e.edad == id);
        }
    }
}
