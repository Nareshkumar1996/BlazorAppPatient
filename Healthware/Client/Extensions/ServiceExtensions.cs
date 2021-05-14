using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Healthware.Shared;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Healthware.Client.Extensions
{
    public static class ServiceExtensions
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string url, AuthenticationHeaderValue authorization)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = authorization;

            var response = await httpClient.SendAsync(request);
            var responseBytes = await response.Content.ReadAsByteArrayAsync();
            return JsonSerializer.Deserialize<T>(responseBytes, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public static async Task PostAsync(this HttpClient httpClient,string url, object T, AuthenticationHeaderValue authorization)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = authorization;

            string json = JsonConvert.SerializeObject(T);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + authorization.Parameter);
            var response = await httpClient.PostAsync(url,data);
            var responseBytes = await response.Content.ReadAsByteArrayAsync();
        }
    }
}
