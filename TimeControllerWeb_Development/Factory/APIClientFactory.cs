using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryController.ClientAPI;

namespace InventoryControllerWeb_Development.Factory
{
    internal static class APIClientFactory
    {
        private static Uri apiuri;

        private static string token;

        private static Lazy<ApiClient> RestClient = new Lazy<ApiClient>(() => new ApiClient(apiuri, token), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        static APIClientFactory()
        {
            apiuri = new Uri(MyConfiguration.WebApiBaseUrl);
            token = new string(MyConfiguration.Token);
        }

        public static ApiClient Instance
        {
            get
            {
                return RestClient.Value;
            }
        }
    }
}
