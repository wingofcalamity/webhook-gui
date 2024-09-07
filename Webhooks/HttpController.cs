using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Webhooks
{
    internal class HttpController
    {
        private readonly HttpClient _httpClient;
        private readonly XManager webhookManager;
        public HttpController() {
            _httpClient = new HttpClient();
            webhookManager = new XManager("settings.xml");
        }
        public async Task<string> PostAsync(string url, string jsonContent)
        {
            try
            {
                // Create the content to send
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                // Ensure we get a successful response
                response.EnsureSuccessStatusCode();

                // Read and return the response content
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task sendAsync(string message)
        {
            string url = webhookManager.Load();
            string body = $"{{\"content\":\"{message}\"}}";
            _ = await PostAsync(url, body);
        }
    }
}
