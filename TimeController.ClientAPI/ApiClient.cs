using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InventoryController.ClientAPI.Wrappers;
using InventoryController.Models;

namespace InventoryController.ClientAPI
{
    public partial class ApiClient
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }

        public ApiClient(Uri baseEndpoint, string token)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();

        }
        
        private async Task<Response<T>> GetAsync<T>(Uri requestUrl, string token = "")
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    if (data == null)
                    {
                        return new Response<T>(("Recored Not Found"));
                    }
                    var retuenvalue = new Response<T>(JsonConvert.DeserializeObject<T>(data));
                    return retuenvalue;
                }
                else
                {
                    return new Response<T>((response.StatusCode.ToString()));
                }
            }
            catch(Exception ex)
            {
                throw ex;
            
            }
        }
        private async Task<Response<T>> GetAsync1<T>(Uri requestUrl, string token = "")
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    var datares = await response.Content.ReadAsStringAsync();
                    if (datares == null)
                    {
                        return new Response<T>(("Recored Not Found"));
                    }
                    var retuenvalue = JsonConvert.DeserializeObject<Response<T>>(datares);
                    //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    //return serializer.Deserialize<T>(json);
                    //var retuenvalue = new Response<T>(JsonConvert.DeserializeObject<T>(datares));
                    return retuenvalue;
                }
                else
                {
                    return new Response<T>((response.StatusCode.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private async Task<Response<T>> GetAsyncTask<T>(Uri requestUrl, string token = "")
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    var datares = await response.Content.ReadAsStringAsync();
                    if (datares == null)
                    {
                        return new Response<T>(("Recored Not Found"));
                    }
                    var retuenvalue = JsonConvert.DeserializeObject<Response<T>>(datares);
                    //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    //rar retueneturn serializer.Deserialize<T>(json);
                    //vvalue = new Response<T>(JsonConvert.DeserializeObject<T>(datares));
                    return retuenvalue;
                }
                else
                {
                    return new Response<T>((response.StatusCode.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        //public async Task<Response<ProjectModel>> GetProjectById(int id, string token = "")
        //{
        //    var requestUrl = CreateRequestUri($"Project/{id}");
        //    return await GetAsync<ProjectModel>(requestUrl, token);
        //}

        //public async Task<Response<ProjectModel>> UpdateProject(int id, ProjectModel updatedProject, string token = "")
        //{
        //    var requestUrl = CreateRequestUri($"Project/{id}");
        //    return await GetAsync<ProjectModel>(requestUrl, updatedProject, token);
        //}


        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<Message<T>> PostAsync<T>(Uri requestUrl, T content)
        {

            try 
                {
                var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Message<T>>(data);
            }
            catch(Exception ex)
            {
                return JsonConvert.DeserializeObject<Message<T>>("");
            }
        }

        private async Task<LoginResponseModel> PostAsync<LoginResponseModel, T2>(Uri requestUrl, T2 content)
        {

            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var returndata = JsonConvert.DeserializeObject<LoginResponseModel>(data);
            return returndata;
        }

        private async Task<Message<T>> TaskPostAsync<T>(Uri requestUrl, T content)
        {

            try
            {
                var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Message<T>>(data);
            }
            catch (Exception ex)
            {
                return JsonConvert.DeserializeObject<Message<T>>("");
            }
        }

        private async Task<LoginResponseModel> TaskPostAsync<LoginResponseModel, T2>(Uri requestUrl, T2 content)
        {

            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var returndata = JsonConvert.DeserializeObject<LoginResponseModel>(data);
            return returndata;
        }

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        private void addHeaders()
        {
            _httpClient.DefaultRequestHeaders.Remove("userIP");
            _httpClient.DefaultRequestHeaders.Add("userIP", "192.168.1.1");
        }
    }
}
