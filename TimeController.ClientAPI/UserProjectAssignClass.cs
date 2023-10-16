using System;
using System.Collections.Generic;
using System.Text;
using InventoryController.Models;

namespace InventoryController.ClientAPI
{
    public class UserProjectAssignClass : AuditableEntity
    {
        public Int64 ProjectId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Userid { get; set; }

        public bool Deleted { get; set; } = false;
    }
}
