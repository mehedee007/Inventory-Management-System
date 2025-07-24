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
    public class ReceiveService : IReceiveService
    {
        private readonly ApplicationDBContext _context;
        public ReceiveService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task AddReceiveAsync(ReceiveHeader recHeader)
        {
            recHeader.RecNo = await GenerateReceiveNoAsync();
            _context.ReceiveHeader.Add(recHeader);
            await _context.SaveChangesAsync();
            //foreach(var product in recHeader.ReceiveDetails)
            //{
            //    var existingProduct = _context.Database.SqlQueryRaw<Stock>("", product.OrderDetailId);
            //    if (existingProduct)
            //    {

            //    }
            //}
        }

        public async Task<string> GenerateReceiveNoAsync()
        {
            var now = DateTime.Now;
            string prefix = $"REC-{now:yy-MM}";

            // Count existing receives on the current month
            int countThisMonth = await _context.ReceiveHeader
                .CountAsync(o => o.ReceivedDate.Year == now.Year && o.ReceivedDate.Month == now.Month);

            string recNo = $"{prefix}-{(countThisMonth + 1).ToString("D6")}";

            return recNo;
        }

        public Task<IEnumerable<ReceiveHeader>> GetAllReceiveNoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
