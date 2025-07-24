using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Interfaces
{
    public interface IReceiveService
    {
        Task<string> GenerateReceiveNoAsync();
        Task<IEnumerable<ReceiveHeader>> GetAllReceiveNoAsync();
        Task AddReceiveAsync(ReceiveHeader recHeader);
    }
}
