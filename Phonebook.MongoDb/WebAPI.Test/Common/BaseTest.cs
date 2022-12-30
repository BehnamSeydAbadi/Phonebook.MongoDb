using Microsoft.AspNetCore.Mvc.Testing;

namespace WebAPI.Test.Common
{
    public abstract class BaseTest
    {
        protected readonly HttpClient _httpClient;
        private readonly string _uri;

        public BaseTest(string uri)
        {
            var factory = new WebApplicationFactory<Program>();
            _httpClient = factory.CreateDefaultClient();

            _uri = uri;
        }

        protected async Task<OutputViewModel> PostAsync<TValue>(TValue value)
        {
            var response = await _httpClient.PostAsJsonAsync(_uri, value);

            return await DeserializeResponse(response.Content);
        }

        protected async Task<OutputViewModel> GetAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{_uri}/{id}");

            return await DeserializeResponse(response.Content);
        }

        protected TValue DeserializeJson<TValue>(string json)
            => JsonConvert.DeserializeObject<TValue>(json);

        private async Task<OutputViewModel> DeserializeResponse(HttpContent httpContent)
        {
            var stringResult = await httpContent.ReadAsStringAsync();

            return DeserializeJson<OutputViewModel>(stringResult);
        }
    }
}