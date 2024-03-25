using Contracts.RequestModels.Customer;
using Entity.Entity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;

namespace UnitTestingTraining
{
    public class Tests : BaseTest
    {
        private readonly HttpClient _client;

        public Tests()
        {
            _client = GetClient;
        }
        //[OneTimeSetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public async Task Test1()
        {
            //Arrange
            var client = _factory.CreateClient();
            var fromBody = new CreateCustomerRequest()
            {
                Name = "Product 1",
                Email = "andrew@gmail.com"
            };


            //Act
            //var response = await client.GetAsync("api/v1/customer");
            var response = await client.PostAsync("api/v1/customer", new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json"));
            //Assert

            Assert.That(response.IsSuccessStatusCode, Is.False);
            Assert.Pass();
        }
    }
}