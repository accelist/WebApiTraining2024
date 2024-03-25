using Contracts.RequestModels.Customer;
using Entity.Entity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;

namespace CustomerTesting
{
    [TestFixture]
    public class Tests : BaseTest
    {
        private readonly HttpClient _client;
        public Tests()
        {
            _client = GetClient;
        }

        [Test]
        public async Task TestCreate()
        {
            // arrange
            var client = _factory.CreateClient();
            var fromBody = new CreateCustomerRequest()
            {
                //CustomerID = Guid.NewGuid(),
                Name = "CustomerTest6",
                Email = "customerTest6@gmail.com"
            };
            // act
            //var response = await client.GetAsync("api/v1/customer");
            var temp = new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/v1/customer", temp);

            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test]
        public async Task TestGet()
        {
            // arrange
            var client = _factory.CreateClient();

            var response = await client.GetAsync("api/v1/customer");

            //var content = await response.Content.ReadAsStringAsync();

            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task TestGetByID()
        {
            // arrange
            var client = _factory.CreateClient();

            var response = await client.GetAsync("api/v1/customer");

            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task TestUpdate()
        {
            // arrange
            var client = _factory.CreateClient();
            var fromBody = new UpdateCustomerModel()
            {
                Name = "UpdatedName",
                Email = "UpdatedName@gmail.com"
            };

            // act
            var temp = new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"api/v1/customer/3c2914a7-fa2e-486d-9b7b-7d5d650974c3", temp);

            // assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task TestDelete()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var response = await _client.DeleteAsync($"api/v1/customer/customer id here");

            // assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}