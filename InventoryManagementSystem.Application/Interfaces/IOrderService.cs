using InventoryManagementSystem.Application.ViewModels;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Interfaces
{
    public interface IOrderService
    {
        Task<string> GenerateOrderNoAsync();
        Task<IEnumerable<OrderHeader>> GetAllOrdersAsync();
        Task AddOrderAsync(OrderHeader orderHeader);
        Task<IEnumerable<PendingOrderVm>> GetPendingOrdersBySupplierAsync(int supplierId);
        Task<IEnumerable<PendingItemVm>> GetPendingItemsByOrderAsync(int orderHeaderId);


    }
}
