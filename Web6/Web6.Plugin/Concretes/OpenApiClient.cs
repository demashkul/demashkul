using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Web6.Plugin.Abstracts;

namespace Web6.Plugin.Concretes
{
    public class OpenApiClient : IOpenApi
    {
        private string serviceName = "api1";
        private readonly IHttpClientFactory httpClientFactory;
        public OpenApiClient(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task CallServiceAsync(string token)
        {

            var client = httpClientFactory.CreateClient(serviceName);
            client.DefaultRequestHeaders.Authorization =new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",token);
            var response = await client.GetAsync("product/get");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var xa = JsonSerializer.Deserialize<string[]>(content);
            }
        } 
        public bool CallService(string token)
        {

            var client = httpClientFactory.CreateClient(serviceName);
            client.DefaultRequestHeaders.Authorization =new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",token);
            var response = client.GetAsync("product/get").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var xa = JsonSerializer.Deserialize<string[]>(content);
                return true;
            }
            return false;
        }
    }
}
