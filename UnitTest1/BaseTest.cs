using Entity.Entity;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TrainingUnitTesting
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
