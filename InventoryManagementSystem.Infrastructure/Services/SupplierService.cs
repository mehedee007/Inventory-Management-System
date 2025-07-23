using InventoryManagementSystem.Application.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Infrastructure.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDBContext _context;

        public SupplierService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
        }

        public Task DeleteSupplierAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> GetSupplierByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSupplierAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
