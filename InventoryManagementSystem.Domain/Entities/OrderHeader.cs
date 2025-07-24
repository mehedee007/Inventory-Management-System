using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    public class OrderHeader
    {
        [Key]
        public int OrderHeaderId { get; set; }
        [ValidateNever]
        public required string OrderNo { get; set; }
        [Required]
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        [ValidateNever]
        public required ICollection<OrderDetails> OrderDetails { get; set; }

        // Navigation Property
        [ValidateNever]
        public Supplier Supplier { get; set; } 



    }
}
