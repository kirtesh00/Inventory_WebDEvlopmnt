using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using InventoryController.Models;
using InventoryControllerWeb_Development.Factory;

namespace InventoryControllerWeb_Development.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(IFormCollection collection)
        {
            try
            {
                RegisterModel registerModel = new RegisterModel();
                registerModel.FirstName = collection["FirstName"];
                registerModel.LastName = collection["LastName"];
                registerModel.UserName = collection["UserName"];
                registerModel.Email = collection["Email"];
                registerModel.Password = collection["Password"];
                var data = await APIClientFactory.Instance.Register(registerModel);
                return RedirectToAction(nameof(Login));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(IFormCollection collection)
        {
            try
            {
                LoginModel loginModel = new LoginModel();
                loginModel.Username = collection["UserName"];
                loginModel.Password = collection["Password"];
                var data = await APIClientFactory.Instance.Login(loginModel);
                if(data.token != null && data.token != "")
                {
                    MyConfiguration.Token = data.token;
                }
                return RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
