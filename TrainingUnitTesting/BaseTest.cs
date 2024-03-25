using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;


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
