using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryController.Models
{
    public class TaskModel:AuditableEntity
    {
        public Int64 ProjectId { get; set; }
        public string TaskName { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
