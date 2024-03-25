using Contracts.RequestModels.Product;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CustomerTesting
{
    [TestFixture]
    public class Tests : BaseTestProduct
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
            var fromBody = new CreateProductRequest()
            {
                Name = "ProductTest",
                Price = 110000
            };
            // act
            //var response = await client.GetAsync("api/v1/customer");
            var temp = new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/v1/product", temp);

            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test]
        public async Task TestGet()
        {
            // arrange
            var client = _factory.CreateClient();

            var response = await client.GetAsync("api/v1/product");

            //var content = await response.Content.ReadAsStringAsync();

            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task TestGetByID()
        {
            // arrange
            var client = _factory.CreateClient();

            var response = await client.GetAsync("api/v1/product");

            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task TestUpdate()
        {
            // arrange
            var client = _factory.CreateClient();
            var fromBody = new UpdateProductModel()
            {
                Name = "UpdatedName",
                Price = 120000
            };

            // act
            var temp = new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"api/v1/product/product id", temp);

            // assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task TestDelete()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var response = await _client.DeleteAsync($"api/v1/product/product id here");

            // assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}