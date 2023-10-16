using Microsoft.AspNetCore.Mvc;

namespace InventoryControllerWeb_Development.Views.Shared.Components.FormModal
{
    public class FormModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
