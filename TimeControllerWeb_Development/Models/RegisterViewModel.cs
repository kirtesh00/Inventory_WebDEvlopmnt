using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControllerWeb_Development.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last Name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
