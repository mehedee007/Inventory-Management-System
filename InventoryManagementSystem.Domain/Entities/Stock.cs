using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public decimal SIH { get; set; }
        public DateTime UpdatedOn { get; set; }

        //Navigation Properties
        [ValidateNever]
        [ForeignKey("ProductId")]

        public Product Product { get; set; }

    }
}
