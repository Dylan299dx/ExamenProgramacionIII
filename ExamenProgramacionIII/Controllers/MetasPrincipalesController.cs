using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenProgramacionIII.Data;
using ExamenProgramacionIII.Models;

namespace ExamenProgramacionIII.Controllers
{
    public class MetasPrincipalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MetasPrincipalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MetasPrincipales
        public async Task<IActionResult> Index()
        {
            return View(await _context.MetasPrincipales.ToListAsync());
        }

        // GET: MetasPrincipales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metaPrincipal = await _context.MetasPrincipales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metaPrincipal == null)
            {
                return NotFound();
            }

            return View(metaPrincipal);
        }

        // GET: MetasPrincipales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MetasPrincipales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,Categoria,FechaCreacion,FechaLimite,Prioridad,Estado")] MetaPrincipal metaPrincipal)
        {
            try
            {
                _context.Add(metaPrincipal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
            return View(metaPrincipal);
        }

        // GET: MetasPrincipales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metaPrincipal = await _context.MetasPrincipales.FindAsync(id);
            if (metaPrincipal == null)
            {
                return NotFound();
            }
            return View(metaPrincipal);
        }

        // POST: MetasPrincipales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,Categoria,FechaCreacion,FechaLimite,Prioridad,Estado")] MetaPrincipal metaPrincipal)
        {
            if (id != metaPrincipal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metaPrincipal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetaPrincipalExists(metaPrincipal.Id))
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
            return View(metaPrincipal);
        }

        // GET: MetasPrincipales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metaPrincipal = await _context.MetasPrincipales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metaPrincipal == null)
            {
                return NotFound();
            }

            return View(metaPrincipal);
        }

        // POST: MetasPrincipales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metaPrincipal = await _context.MetasPrincipales.FindAsync(id);
            if (metaPrincipal != null)
            {
                _context.MetasPrincipales.Remove(metaPrincipal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetaPrincipalExists(int id)
        {
            return _context.MetasPrincipales.Any(e => e.Id == id);
        }
    }
}
