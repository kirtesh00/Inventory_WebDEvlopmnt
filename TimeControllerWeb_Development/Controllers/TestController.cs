using InventoryControllerWeb_Development.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace InventoryControllerWeb_Development.Controllers
{
	public class TestController : Controller
	{
		private readonly IConfiguration configuration;
		public TestController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
        public IActionResult Index()
		{
			var connectionstring = "Data Source=.;Initial Catalog=DemoProject;User ID=sa;Password=123";
			List<State> statesList = new List<State>();
			List<Designation> designationlist = new List<Designation>();
			using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
			{
				using (SqlCommand command = new SqlCommand("SELECT * FROM State", sqlConnection))
				{
					command.CommandType = CommandType.Text;
					sqlConnection.Open();
					using (SqlDataReader sdr = command.ExecuteReader())
					{
						while (sdr.Read())
						{
							var state = new State()
							{
								StateId = (int)sdr["StateId"],
								States = (string)sdr["State"]
							};
							statesList.Add(state);
						}
					}
				}
				using (SqlCommand command = new SqlCommand("SELECT * FROM Designation", sqlConnection))
				{
					command.CommandType = CommandType.Text;
					using (SqlDataReader sdr = command.ExecuteReader())
					{
						while (sdr.Read())
						{
							var Designation = new Designation()
							{
								DesignationId = (int)sdr["DesignationId"],
								Designations = (string)sdr["Designation"]
							};
							designationlist.Add(Designation);
						}
					}
				}
			}
			if (statesList != null && designationlist != null)
			{
				ViewBag.States = new SelectList(statesList, "StateId", "States");
				ViewBag.Designation  = new SelectList(designationlist, "DesignationId", "Designations");
			}
			return View();
		}
		public IActionResult SaveData(User user)
		{
			if(user != null) 
			{ 

			
			}

			return View();	
		}
	}
}
	