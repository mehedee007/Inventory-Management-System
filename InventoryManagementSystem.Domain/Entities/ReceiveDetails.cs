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
    public class ReceiveDetails
    {
        [Key]
        public int ReceiveDetailId { get; set; }
        [Required]
        public int ReceiveHeaderId { get; set; }
        [Required]
        public decimal Qty { get; set; }
        public decimal BalanceQty { get; set; }

        public int OrderDetailId { get; set; }

        //Navigation Properties
        [ValidateNever]
        [ForeignKey("ReceiveHeaderId")]

        public ReceiveHeader ReceiveHeader { get; set; }
        [ValidateNever]
        [ForeignKey("OrderDetailId")]

        public OrderDetails OrderDetails { get; set; }
    }
}
