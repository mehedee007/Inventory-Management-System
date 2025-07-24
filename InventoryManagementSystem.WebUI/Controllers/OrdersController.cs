using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Data;
using InventoryManagementSystem.Application.Interfaces;

namespace InventoryManagementSystem.WebUI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private readonly IOrderService _orderService;

        public OrdersController(IProductService productService, ISupplierService supplierService, IOrderService orderService)
        {
            _productService = productService;
            _supplierService = supplierService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Suppliers = new SelectList(await _supplierService.GetAllAsync(), "SupplierId", "SupplierName");
            ViewBag.Products = new SelectList(await _productService.GetAllAsync(),"ProductId","ProductName");
            return View();
        }

        //// GET: OrderHeaders
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDBContext = _context.OrderHeader.Include(o => o.Supplier);
        //    return View(await applicationDBContext.ToListAsync());
        //}

        //// GET: OrderHeaders/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderHeader = await _context.OrderHeader
        //        .Include(o => o.Supplier)
        //        .FirstOrDefaultAsync(m => m.OrderHeaderId == id);
        //    if (orderHeader == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(orderHeader);
        //}

        //// GET: OrderHeaders/Create
        //public IActionResult Create()
        //{
        //    ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName");
        //    return View();
        //}

        // POST: OrderHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,OrderDetails")] OrderHeader orderHeader)
        {
            if (ModelState.IsValid)
            {
                await _orderService.AddOrderAsync(orderHeader);
                return RedirectToAction(nameof(Create)); // Or RedirectToAction("Index") if you have one
            }
            // Repopulate dropdowns on failure
            ViewBag.Suppliers = new SelectList(await _supplierService.GetAllAsync(), "SupplierId", "SupplierName");
            ViewBag.Products = new SelectList(await _productService.GetAllAsync(), "ProductId", "ProductName");

            return View(orderHeader);
        }


        //// GET: OrderHeaders/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderHeader = await _context.OrderHeader.FindAsync(id);
        //    if (orderHeader == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName", orderHeader.SupplierId);
        //    return View(orderHeader);
        //}

        //// POST: OrderHeaders/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("OrderHeaderId,OrderNo,SupplierId,OrderDate")] OrderHeader orderHeader)
        //{
        //    if (id != orderHeader.OrderHeaderId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(orderHeader);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrderHeaderExists(orderHeader.OrderHeaderId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName", orderHeader.SupplierId);
        //    return View(orderHeader);
        //}



        //private bool OrderHeaderExists(int id)
        //{
        //    return _context.OrderHeader.Any(e => e.OrderHeaderId == id);
        //}
    }
}
