using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace UnitTest1
{
    public class Tests : BaseTest
    {
        private readonly HttpClient _client;
        public Tests()
        {
            _client = GetClient;
        }
        [SetUp]
        public void Setup()
        {
        }

        private Guid testCustomerId;
        private readonly string url = "api/v1/customer";

        [Test, Order(1)]
        public async Task TestPost()
        {
            //Arrange
            var client = _factory.CreateClient();

            var customer = new CreateCustomerRequest
            {
                Name = "TestName",
                Email = "TestEmail@gmail.com"
            };


            //Act
            var stringContent = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, stringContent);
            CreateCustomerResponse? responseContent = await response.Content.ReadFromJsonAsync<CreateCustomerResponse>();
            if(responseContent != null)
            {
                testCustomerId = responseContent.CustomerID;
            }
            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }
        [Test, Order(2)]
        public async Task TestGet()
        {
            //Arrange
            var client = _factory.CreateClient();


            //Act
            var response = await client.GetAsync(url);


            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }
        [Test, Order(3)]
        public async Task TestGetDetail()
        {
            //Arrange
            var client = _factory.CreateClient();


            //Act
            var response = await client.GetAsync($"{url}/{testCustomerId}");


            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test, Order(4)]
        public async Task TestPut()
        {
            //Arrange
            var client = _factory.CreateClient();
            var content = new UpdateCustomerModel
            {
                Name = "TESTUPDATENAME",
                Email = "updatedEmail@email.com"
            };

            //Act
            var stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{url}/{testCustomerId}", stringContent);

            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test, Order(5)]
        public async Task TestDelete()
        {
            //arrange
            var client = _factory.CreateClient();

            //act
            var response = await client.DeleteAsync($"{url}/{testCustomerId}");

            //assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }
    }
}