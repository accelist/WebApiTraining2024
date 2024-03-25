using Microsoft.AspNetCore.Mvc.Testing;
namespace APITestingUnit
{
    public class BaseTest
    {
        protected readonly WebApplicationFactory<Program> _factory;
        public BaseTest()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        public HttpClient GetClient => _factory.CreateClient();
    }
}
