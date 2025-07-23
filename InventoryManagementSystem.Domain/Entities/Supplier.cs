using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public required string SupplierName { get; set; }
        public string? SupplierEmail { get; set; }
        public required string SupplierPhone { get; set; }
        public string? Address { get; set; }
        public DateTime EnteredOn { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public DateTime UpdatedOn { get; set; }

    }
}
