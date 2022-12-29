using Microsoft.AspNetCore.Mvc.Testing;

namespace WebAPI.Test.Common
{
    public abstract class BaseTest
    {
        protected readonly HttpClient _httpClient;

        public BaseTest()
        {
            var factory = new WebApplicationFactory<Program>();
            _httpClient = factory.CreateDefaultClient();
        }
    }
}