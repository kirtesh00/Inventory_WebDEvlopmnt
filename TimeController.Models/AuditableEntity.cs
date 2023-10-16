using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryController.Models
{
    public class AuditableEntity
    {
        public Int64 Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
