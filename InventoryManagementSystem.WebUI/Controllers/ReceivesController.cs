using InventoryManagementSystem.Application.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.WebUI.Controllers
{
    public class ReceivesController : Controller
    {
        private readonly IReceiveService _receiveService;
        private readonly ISupplierService _supplierService;
        private readonly IOrderService _orderService;
        public ReceivesController(IReceiveService receiveService, ISupplierService supplierService, IOrderService orderService)
        {
            _receiveService = receiveService;
            _supplierService = supplierService;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Suppliers = new SelectList(await _supplierService.GetAllAsync(), "SupplierId", "SupplierName");
            return View();
        }

        

        // POST: ReceiveHeader/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceiveDetails")] ReceiveHeader receive)
        {
            if (ModelState.IsValid)
            {
                await _receiveService.AddReceiveAsync(receive);
                return RedirectToAction(nameof(Create)); // Or RedirectToAction("Index") if you have one
            }
            // Repopulate dropdowns on failure
            ViewBag.Suppliers = new SelectList(await _supplierService.GetAllAsync(), "SupplierId", "SupplierName");

            return View(receive);
        }

        [HttpGet]
        public async Task<IActionResult> GetPendingOrdersBySupplier(int supplierId)
        {
            var pendingOrders = await _orderService.GetPendingOrdersBySupplierAsync(supplierId);
            return Json(pendingOrders);
        }

        [HttpGet]
        public async Task<IActionResult> GetPendingItemsByOrder(int orderHeaderId)
        {
            var items = await _orderService.GetPendingItemsByOrderAsync(orderHeaderId);
            return Json(items);
        }





    }
}
