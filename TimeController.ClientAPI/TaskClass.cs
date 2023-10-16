using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InventoryController.ClientAPI.Wrappers;
using InventoryController.Models;

namespace InventoryController.ClientAPI
{
    public partial class ApiClient
    {
        public async Task<Response<IEnumerable<TaskModel>>> GetTask(string token = "")
        {
            try
            {
                var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Task"));
                var returnValue = await GetAsyncTask<IEnumerable<TaskModel>>(requestUrl, token);

                if (returnValue.Succeeded)
                {
                    if (returnValue.Data != null && returnValue.Data.Any())
                    {
                        return new Response<IEnumerable<TaskModel>>(returnValue.Data, "Success");
                    }
                    else
                    {
                        // Handle the case when the data is empty or null
                        var response = new Response<IEnumerable<TaskModel>>("No projects found.");
                        return response;
                    }
                }
                else
                {
                    var response = new Response<IEnumerable<TaskModel>>(returnValue.Message);
                    return response;
                }
            }
            catch (JsonSerializationException ex)
            {
                return new Response<IEnumerable<TaskModel>>("Error deserializing JSON: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                return new Response<IEnumerable<TaskModel>>("Error making HTTP request: " + ex.Message);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<TaskModel>>("Unexpected error occurred: " + ex.Message);
            }
        }


        public async Task<Message<TaskModel>> SaveTask(TaskModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Task"));
            return await TaskPostAsync<TaskModel>(requestUrl, model);
        }
    }
}



