using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    public class ReceiveHeader
    {
        [Key]
        public int ReceiveHeaderId { get; set; }
        [ValidateNever]
        public required string RecNo { get; set; }
        public DateTime ReceivedDate { get; set; } = DateTime.UtcNow;
        [ValidateNever]
        public ICollection<ReceiveDetails> ReceiveDetails { get; set; }
    }
}
