using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Product;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingUnitTraining
{
    public class TestCart : BaseTest
    {
        private readonly HttpClient _client;

        public TestCart()
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
            var fromBody = new CreateCartRequest
            {
                Quantity = 6,
                CustomerID = new Guid("3a47f4c0-586e-4ccb-99c7-24f3e5599feb"),
                ProductID = new Guid("d85608dc-c0ad-49f5-9811-07bb858a9a2e")
            };

            //Act
            var temp = new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/v1/cart", temp);

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
            var response = await client.GetAsync("api/v1/cart");
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
            var id = "3bf241b7-675d-477b-b6bf-e7531cc8d2bc";
            //Assert
            var response = await client.GetAsync("api/v1/cart" + "/" + id);

            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test]
        [Ignore("ignore")]
        public async Task TestPut()
        {
            //Arrange
            var client = _factory.CreateClient();
            var fromBody = new UpdateCartRequest
            {
                Quantity = 3
            };
            var temp = new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");
            var id = "571a37b5-544a-4c5e-92ca-458dfe7c260b";
            //Act
            var response = await client.PutAsync("api/v1/cart" + "/" + id, temp);
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
            var id = "ba9fbc90-005f-4c50-a457-b6d63c38e648";
            //Assert
            var response = await client.DeleteAsync("api/v1/cart" + "/" + id);

            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }
    }
}
