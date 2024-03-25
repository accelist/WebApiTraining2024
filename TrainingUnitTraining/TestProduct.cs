using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingUnitTraining
{
    public class TestProduct: BaseTest
    {
        private readonly HttpClient _client;
        public TestProduct()
        {
            _client = GetClient;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Ignore("ignore")]
        public async Task TestPost()
        {
            //Arrange
            var client = _factory.CreateClient();
            var fromBody = new CreateProductRequest
            {
                Name = "Pancake",
                Price = 13000
            };

            //Act
            var temp = new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/v1/product", temp);

            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test]
        public async Task TestGet()
        {
            //Arrange
            var client = _factory.CreateClient();
            //Act
            var response = await client.GetAsync("api/v1/product");
            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test]
        public async Task TestGetID()
        {
            //Arrange
            var client = _factory.CreateClient();
            //Act
            var id = "c67e6507-ad86-421f-8c25-87e0411463db";
            //Assert
            var response = await client.GetAsync("api/v1/product" + "/" + id);

            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test]
        [Ignore("ignore")]
        public async Task TestPut()
        {
            //Arrange
            var client = _factory.CreateClient();
            var fromBody = new UpdateProductRequest
            {
                Name = "Pancake3 edit",
                Price = 43000
            };
            var temp = new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");
            var id = "c67e6507-ad86-421f-8c25-87e0411463db";
            //Act
            var response = await client.PutAsync("api/v1/product" + "/" + id, temp);
            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test]
        [Ignore("ignore")]
        public async Task TestDelete()
        {
            //Arrange
            var client = _factory.CreateClient();
            //Act
            var id = "cb1c7899-fb76-4ffa-935a-3ac6fab42b7b";
            //Assert
            var response = await client.DeleteAsync("api/v1/product" + "/" + id);

            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }
    }
}
