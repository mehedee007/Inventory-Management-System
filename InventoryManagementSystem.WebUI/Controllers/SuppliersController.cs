using InventoryManagementSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.WebUI.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly SupplierService _supplierService;
        public SuppliersController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
