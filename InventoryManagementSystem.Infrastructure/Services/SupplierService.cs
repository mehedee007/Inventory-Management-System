using InventoryManagementSystem.Application.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if(supplier != null)
            {
                supplier.IsActive = false;
                supplier.UpdatedOn = DateTime.UtcNow;
                _context.Suppliers.Update(supplier);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            var suppliers = await _context.Suppliers
                    .Where(supplier => supplier.IsActive)
                    .ToListAsync();
            return suppliers;
        }

        public async Task<Supplier> GetByIdAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            return supplier;
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            supplier.UpdatedOn = DateTime.UtcNow;
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
