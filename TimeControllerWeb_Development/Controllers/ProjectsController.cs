using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using InventoryController.Models;
using InventoryControllerWeb_Development.Factory;
using InventoryControllerWeb_Development.Models;

namespace InventoryControllerWeb_Development.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly IOptions<MySettingsModel> _myConfiguration;
        public ProjectsController(ILogger<ProjectsController> logger, IOptions<MySettingsModel> myConfiguration)
        {
            _logger = logger;
            MyConfiguration.WebApiBaseUrl = myConfiguration.Value.WebApiBaseUrl;
            
        }

     
        public async Task<ActionResult> Index()
        {
            var data = await APIClientFactory.Instance.GetProjects(MyConfiguration.Token);
            if (data.Succeeded)
            {
                if (data.Data.Count() > 0)
                    return View(data.Data);
                else
                    return View(new List<ProjectModel>());
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

        // GET: ProjectsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                ProjectModel projectModel = new ProjectModel();
                projectModel.Name = collection["Name"];
                projectModel.Description = collection["Description"];
                projectModel.IsActive = Convert.ToBoolean(collection["IsActive"]);
                var data = await APIClientFactory.Instance.SaveProject(projectModel);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: ProjectsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectsController/Edit/5
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

        // GET: ProjectsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectsController/Delete/5
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
