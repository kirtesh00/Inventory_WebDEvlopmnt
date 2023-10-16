using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using InventoryController.Models;
using InventoryControllerWeb_Development.Factory;
using InventoryControllerWeb_Development.Models;
using System.Linq;

namespace InventoryControllerWeb_Development.Controllers
{
    public class TaskController : Controller
    {
        

        private readonly ILogger<TaskController> _logger;
        private readonly IOptions<MySettingsModel> _myConfiguration;
        private string apiBaseUrl;
        public TaskController(ILogger<TaskController> logger, IOptions<MySettingsModel> myConfiguration)
        {
            _logger = logger;
            MyConfiguration.WebApiBaseUrl = myConfiguration.Value.WebApiBaseUrl;

        }

        // GET: ProjectsController
        //public async Task<ActionResult> Index()
        //{
        //    var data = await APIClientFactory.Instance.GetProjects(MyConfiguration.Token);
        //    if (data.Succeeded)
        //        return View(data);
        //    else
        //    {
        //        return RedirectToAction("login", "Account");
        //    }
        //}
        public async Task<ActionResult> Index()
        {
            var data = await APIClientFactory.Instance.GetTask(MyConfiguration.Token);
            if (data.Succeeded)
            {
                if (data.Data.Count() > 0)
                    return View(data.Data);
                else
                    return View(new List<TaskModel>());
            }
            else
            {
                return RedirectToAction("login", "Account");
            }
        }


        // GET: ProjectsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                TaskModel taskModel = new TaskModel();
                taskModel.TaskName = collection["Name"];
                taskModel.Description = collection["Description"];
                taskModel.IsActive = Convert.ToBoolean(collection["IsActive"]);
                var data = await APIClientFactory.Instance.SaveTask(taskModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
    