using System;

namespace InventoryController.Models
{
    public class LoginResponseModel
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
