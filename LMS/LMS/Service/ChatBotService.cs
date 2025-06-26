using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Services
{
    public class ChatBotService
    {
        private readonly string apiKey;
        private readonly HttpClient client;

        public ChatBotService()
        {
            this.apiKey = "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";
          
            this.client = new HttpClient();
        }

        public async Task<string> GetResponseAsync(string prompt)
        {
            var requestData = new
            {
                model = "deepseek/deepseek-r1:free",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            string requestJson = JsonConvert.SerializeObject(requestData);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            client.DefaultRequestHeaders.Add("HTTP-Referer", "<YOUR_SITE_URL>");
            client.DefaultRequestHeaders.Add("X-Title", "<YOUR_SITE_NAME>");

            for (int attempt = 0; attempt < 3; attempt++)
            {
                try
                {
                    using (var content = new StringContent(requestJson, Encoding.UTF8, "application/json"))
                    {
                        var response = await client.PostAsync("https://openrouter.ai/api/v1/chat/completions", content);

                        if ((int)response.StatusCode == 429)
                        {
                            await Task.Delay(2000);
                            continue;
                        }

                        response.EnsureSuccessStatusCode();

                        var responseJson = await response.Content.ReadAsStringAsync();
                        JObject result = JObject.Parse(responseJson);

                        return result["choices"]?[0]?["message"]?["content"]?.ToString()?.Trim() ?? "No response.";
                    }
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }

            return "Error: Too many requests or failed attempts. Please try again later.";
        }
    }
}
