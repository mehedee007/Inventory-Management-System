using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.ViewModels
{
    public class PendingItemVm
    {
        public int OrderDetailId { get; set; }
        public string ProductName { get; set; }
        public decimal OrderQty { get; set; }
        public decimal ReceivedQty { get; set; }
    }
}
