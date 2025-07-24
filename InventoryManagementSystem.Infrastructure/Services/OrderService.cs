using InventoryManagementSystem.Application.Interfaces;
using InventoryManagementSystem.Application.ViewModels;
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
    public class OrderService : IOrderService
    {
        private readonly ApplicationDBContext _context;
        public OrderService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddOrderAsync(OrderHeader orderHeader)
        {
            orderHeader.OrderNo = await GenerateOrderNoAsync();
            _context.OrderHeader.Add(orderHeader);
            await _context.SaveChangesAsync();

        }

        public async Task<string> GenerateOrderNoAsync()
        {
            var now = DateTime.Now;
            string prefix = $"ORD-{now:yy-MM}";

            // Count existing orders on the current month
            int countThisMonth = await _context.OrderHeader
                .CountAsync(o => o.OrderDate.Year == now.Year && o.OrderDate.Month == now.Month);

            string orderNo = $"{prefix}-{(countThisMonth + 1).ToString("D6")}";

            return orderNo;
        }

        public Task<IEnumerable<OrderHeader>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PendingItemVm>> GetPendingItemsByOrderAsync(int orderHeaderId)
        {
            try
            {
                return await _context.PendingItemVm
            .FromSqlInterpolated($"EXEC spGetPendingItemsByOrder @OrderHeaderId = {orderHeaderId}")
            .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }

        public async Task<IEnumerable<PendingOrderVm>> GetPendingOrdersBySupplierAsync(int supplierId)
        {
            try
            {
                var pendingOrders = await _context.PendingOrderVm
                                .FromSqlInterpolated($"EXEC spGetPendingOrdersBySupplier @SupplierId = {supplierId}")
                                .ToListAsync();
                return pendingOrders;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }



        }
    
    }
}
