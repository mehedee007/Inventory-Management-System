using InventoryManagementSystem.Application.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.WebUI.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.GetAllAsync();
            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier Supplier)
        {
            if (!ModelState.IsValid) return View(Supplier);
            await _supplierService.AddAsync(Supplier);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var Supplier = await _supplierService.GetByIdAsync(id);
            if (Supplier == null) return NotFound();
            return View(Supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Supplier Supplier)
        {
            if (!ModelState.IsValid) return View(Supplier);
            await _supplierService.UpdateAsync(Supplier);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Supplier = await _supplierService.GetByIdAsync(id);
            if (Supplier == null) return NotFound();
            return View(Supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _supplierService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
