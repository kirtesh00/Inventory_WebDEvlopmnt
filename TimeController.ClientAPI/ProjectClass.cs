using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InventoryController.ClientAPI.Wrappers;
using InventoryController.Models;

namespace InventoryController.ClientAPI
{
    public partial class ApiClient
    {
        public async Task<Response<IEnumerable<ProjectModel>>> GetProjects(string token = "")
        {
            try
            {
                var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Project"));
                var returnValue = await GetAsync1<IEnumerable<ProjectModel>>(requestUrl, token);

                if (returnValue.Succeeded)
                {
                    if (returnValue.Data != null && returnValue.Data.Any())
                    {
                        return new Response<IEnumerable<ProjectModel>>(returnValue.Data, "Success");
                    }
                    else
                    {
                        // Handle the case when the data is empty or null
                        var response = new Response<IEnumerable<ProjectModel>>("No projects found.");
                        return response;
                    }
                }
                else
                {
                    var response = new Response<IEnumerable<ProjectModel>>(returnValue.Message);
                    return response;
                }
            }
            catch (JsonSerializationException ex)
            {
                return new Response<IEnumerable<ProjectModel>>("Error deserializing JSON: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                return new Response<IEnumerable<ProjectModel>>("Error making HTTP request: " + ex.Message);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<ProjectModel>>("Unexpected error occurred: " + ex.Message);
            }
        }


        public async Task<Message<ProjectModel>> SaveProject(ProjectModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Project"));
            return await PostAsync<ProjectModel>(requestUrl, model);
        }
    }
}
