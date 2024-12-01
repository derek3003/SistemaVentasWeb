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
    public class MovimientoComprasController : Controller
    {
        private readonly DbventasContext _context;

        public MovimientoComprasController(DbventasContext context)
        {
            _context = context;
        }

        // GET: MovimientoCompras
        public async Task<IActionResult> Index()
        {
            var dbventasContext = _context.MovimientoCompras.Include(m => m.IdProveedorNavigation);
            return View(await dbventasContext.ToListAsync());
        }

        // GET: MovimientoCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoCompra = await _context.MovimientoCompras
                .Include(m => m.IdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (movimientoCompra == null)
            {
                return NotFound();
            }

            return View(movimientoCompra);
        }

        // GET: MovimientoCompras/Create
        public IActionResult Create()
        {
            ViewData["IdProveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "IdProveedor");
            return View();
        }

        // POST: MovimientoCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompra,FechaCompra,IdProveedor,TotalCompra,Detalle")] MovimientoCompra movimientoCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientoCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "IdProveedor", movimientoCompra.IdProveedor);
            return View(movimientoCompra);
        }

        // GET: MovimientoCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoCompra = await _context.MovimientoCompras.FindAsync(id);
            if (movimientoCompra == null)
            {
                return NotFound();
            }
            ViewData["IdProveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "IdProveedor", movimientoCompra.IdProveedor);
            return View(movimientoCompra);
        }

        // POST: MovimientoCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompra,FechaCompra,IdProveedor,TotalCompra,Detalle")] MovimientoCompra movimientoCompra)
        {
            if (id != movimientoCompra.IdCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientoCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoCompraExists(movimientoCompra.IdCompra))
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
            ViewData["IdProveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "IdProveedor", movimientoCompra.IdProveedor);
            return View(movimientoCompra);
        }

        // GET: MovimientoCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoCompra = await _context.MovimientoCompras
                .Include(m => m.IdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (movimientoCompra == null)
            {
                return NotFound();
            }

            return View(movimientoCompra);
        }

        // POST: MovimientoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimientoCompra = await _context.MovimientoCompras.FindAsync(id);
            if (movimientoCompra != null)
            {
                _context.MovimientoCompras.Remove(movimientoCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoCompraExists(int id)
        {
            return _context.MovimientoCompras.Any(e => e.IdCompra == id);
        }
    }
}
