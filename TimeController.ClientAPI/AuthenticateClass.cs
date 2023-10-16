using System.Threading.Tasks;
using InventoryController.ClientAPI.Wrappers;
using InventoryController.Models;

namespace InventoryController.ClientAPI
{
    public partial class ApiClient
    {
  
        public async Task<Message<RegisterModel>> Register(RegisterModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Authenticate/register"));
            return await PostAsync<RegisterModel>(requestUrl, model);
        }

        public async Task<LoginResponseModel> Login(LoginModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Authenticate/login"));
            var responsedata = await PostAsync<LoginResponseModel, LoginModel>(requestUrl, model);
            return responsedata;
        }

        public async Task<Response<string>> CheckAuthorize(string token = "")
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
               "Home/CheckAuthorize"));
            
            var returnvalue = await GetAsync<string>(requestUrl, token);
            if (returnvalue.Succeeded)
                return new Response<string>("Success");
            else
            {
                return new Response<string>(returnvalue.Message);
            }
        }

    }
}
