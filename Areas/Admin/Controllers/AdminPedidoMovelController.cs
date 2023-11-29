using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InduMovel.Context;
using InduMovel.Models;

namespace InduMovel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPedidoMovelController : Controller
    {
        private readonly AppDbContext _context;

        public AdminPedidoMovelController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminPedidoMovel
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PedidoMoveis.Include(p => p.Movel).Include(p => p.Pedido);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/AdminPedidoMovel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PedidoMoveis == null)
            {
                return NotFound();
            }

            var pedidoMovel = await _context.PedidoMoveis
                .Include(p => p.Movel)
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.PedidoMovelId == id);
            if (pedidoMovel == null)
            {
                return NotFound();
            }

            return View(pedidoMovel);
        }

        // GET: Admin/AdminPedidoMovel/Create
        public IActionResult Create(int pedidoId)
        {
            ViewData["MovelId"] = new SelectList(_context.Moveis, "MovelId", "Nome");
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "Cep");
            return View();
        }

        // POST: Admin/AdminPedidoMovel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoMovelId,PedidoId,MovelId,Quantidade,Preco")] PedidoMovel pedidoMovel)
        {
            if (ModelState.IsValid)
            {
                double valorMovel = _context.Moveis.FirstOrDefault(m=>m.MovelId == pedidoMovel.MovelId).Valor;
                _context.Add(pedidoMovel);
                await _context.SaveChangesAsync();
                return RedirectToAction("PedidoMoveis", "AdmimPedido", new { id = pedidoMovel.PedidoId});
            }
            ViewData["MovelId"] = new SelectList(_context.Moveis, "MovelId", "Cor", pedidoMovel.MovelId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "Cep", pedidoMovel.PedidoId);
            return View(pedidoMovel);
        }

        // GET: Admin/AdminPedidoMovel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PedidoMoveis == null)
            {
                return NotFound();
            }

            var pedidoMovel = await _context.PedidoMoveis.FindAsync(id);
            if (pedidoMovel == null)
            {
                return NotFound();
            }
            ViewData["MovelId"] = new SelectList(_context.Moveis, "MovelId", "Cor", pedidoMovel.MovelId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "Cep", pedidoMovel.PedidoId);
            return View(pedidoMovel);
        }

        // POST: Admin/AdminPedidoMovel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoMovelId,PedidoId,MovelId,Quantidade,Preco")] PedidoMovel pedidoMovel)
        {
            if (id != pedidoMovel.PedidoMovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     double valorMovel = _context.Moveis.FirstOrDefault(m=>m.MovelId == pedidoMovel.MovelId).Valor;
                _context.Add(pedidoMovel);
                    _context.Update(pedidoMovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoMovelExists(pedidoMovel.PedidoMovelId))
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
            ViewData["MovelId"] = new SelectList(_context.Moveis, "MovelId", "Cor", pedidoMovel.MovelId);
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "Cep", pedidoMovel.PedidoId);
            return View(pedidoMovel);
        }

        // GET: Admin/AdminPedidoMovel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PedidoMoveis == null)
            {
                return NotFound();
            }

            var pedidoMovel = await _context.PedidoMoveis
                .Include(p => p.Movel)
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.PedidoMovelId == id);
            if (pedidoMovel == null)
            {
                return NotFound();
            }

            return View(pedidoMovel);
        }

        // POST: Admin/AdminPedidoMovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PedidoMoveis == null)
            {
                return Problem("Entity set 'AppDbContext.PedidoMoveis'  is null.");
            }
            var pedidoMovel = await _context.PedidoMoveis.FindAsync(id);
            if (pedidoMovel != null)
            {
                _context.PedidoMoveis.Remove(pedidoMovel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("PedidoMoveis", "AdmimPedido", new { id = pedidoMovel.PedidoId});
        }

        private bool PedidoMovelExists(int id)
        {
          return _context.PedidoMoveis.Any(e => e.PedidoMovelId == id);
        }
    }
}
