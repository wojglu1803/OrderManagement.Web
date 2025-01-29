using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using OrderManagement.Data.Models;

namespace OrderManagement.Web.Controllers
{
    [Authorize]

    public class OrdersController : Controller
    {
       

        private readonly OrderDbContext _context;


        public OrdersController(OrderDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orderDbContext = _context.Orders.Include(o => o.Customer);
            return View(await orderDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product) // Pobranie powiązanych produktów
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }


        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            // Wypełnianie ViewData listą klientów i produktów
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            ViewBag.Products = await _context.Products.ToListAsync();
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderDate,CustomerId")] Order order, int[] SelectedProducts)
        {
            if (ModelState.IsValid)
            {
                // Ustawienie obecnej daty i godziny, jeśli OrderDate jest pusty
                if (order.OrderDate == default(DateTime))
                {
                    order.OrderDate = DateTime.Now;
                }

                _context.Add(order);
                await _context.SaveChangesAsync();

                // Dodanie produktów do zamówienia
                foreach (var productId in SelectedProducts)
                {
                    _context.OrderProducts.Add(new OrderProduct
                    {
                        OrderId = order.Id,
                        ProductId = productId
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Ponowne wypełnienie ViewData w razie błędów
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", order.CustomerId);
            ViewBag.Products = await _context.Products.ToListAsync();
            return View(order);
        }


        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", order.CustomerId);
            ViewBag.Products = await _context.Products.ToListAsync(); // Pobranie wszystkich produktów
            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderDate,CustomerId")] Order order, int[] SelectedProducts)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();

                    // Aktualizacja produktów w zamówieniu
                    var existingOrderProducts = _context.OrderProducts.Where(op => op.OrderId == order.Id);
                    _context.OrderProducts.RemoveRange(existingOrderProducts);

                    foreach (var productId in SelectedProducts)
                    {
                        _context.OrderProducts.Add(new OrderProduct
                        {
                            OrderId = order.Id,
                            ProductId = productId
                        });
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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

            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", order.CustomerId);
            ViewBag.Products = await _context.Products.ToListAsync();
            return View(order);
        }


        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                // Usuń powiązania produktów
                var existingOrderProducts = _context.OrderProducts.Where(op => op.OrderId == order.Id);
                _context.OrderProducts.RemoveRange(existingOrderProducts);

                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}