using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public required string ProductCode { get; set; }
        public required string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public DateTime EnteredOn { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        
    }
}
