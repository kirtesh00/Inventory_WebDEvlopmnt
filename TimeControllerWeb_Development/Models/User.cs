using System;

namespace InventoryControllerWeb_Development.Models
{
	public class User
	{
		public int UserId { get; set; }

		public string Name { get; set; }

		public string Address { get; set; }

		public int? StateId { get; set; } // Use int? to allow for NULL values

		public string Phone { get; set; }

		public DateTime? DOB { get; set; } // Use DateTime? to allow for NULL values

		public int? DesignationId { get; set; } // Use int? to allow for NULL values

		public string UserName { get; set; }

		public string Password { get; set; }

		public bool IsAdmin { get; set; }

		public bool IsActive { get; set; }

		public DateTime? CreateDate { get; set; } // Use DateTime? to allow for NULL values

		public int? CreateBy { get; set; } // Use int? to allow for NULL values

		public DateTime? ModifiedDate { get; set; } // Use DateTime? to allow for NULL values

		public int? ModifiedBy { get; set; } // Use int? to allow for NULL values


	}
}
