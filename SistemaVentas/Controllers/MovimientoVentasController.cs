using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Models;

namespace SistemaVentas.Controllers
{
    public class MovimientoVentasController : Controller
    {
        private readonly DbventasContext _context;

        public MovimientoVentasController(DbventasContext context)
        {
            _context = context;
        }

        // GET: MovimientoVentas
        public async Task<IActionResult> Index()
        {
            var dbventasContext = _context.MovimientoVentas.Include(m => m.IdClienteNavigation);
            return View(await dbventasContext.ToListAsync());
        }

        // GET: MovimientoVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoVenta = await _context.MovimientoVentas
                .Include(m => m.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (movimientoVenta == null)
            {
                return NotFound();
            }

            return View(movimientoVenta);
        }

        // GET: MovimientoVentas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            return View();
        }

        // POST: MovimientoVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,FechaVenta,IdCliente,TotalVenta,Detalle")] MovimientoVenta movimientoVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientoVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", movimientoVenta.IdCliente);
            return View(movimientoVenta);
        }

        // GET: MovimientoVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoVenta = await _context.MovimientoVentas.FindAsync(id);
            if (movimientoVenta == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", movimientoVenta.IdCliente);
            return View(movimientoVenta);
        }

        // POST: MovimientoVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,FechaVenta,IdCliente,TotalVenta,Detalle")] MovimientoVenta movimientoVenta)
        {
            if (id != movimientoVenta.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientoVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoVentaExists(movimientoVenta.IdVenta))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", movimientoVenta.IdCliente);
            return View(movimientoVenta);
        }

        // GET: MovimientoVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoVenta = await _context.MovimientoVentas
                .Include(m => m.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (movimientoVenta == null)
            {
                return NotFound();
            }

            return View(movimientoVenta);
        }

        // POST: MovimientoVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimientoVenta = await _context.MovimientoVentas.FindAsync(id);
            if (movimientoVenta != null)
            {
                _context.MovimientoVentas.Remove(movimientoVenta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoVentaExists(int id)
        {
            return _context.MovimientoVentas.Any(e => e.IdVenta == id);
        }
    }
}
