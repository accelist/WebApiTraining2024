using System.Text;
using Contracts.RequestModels.Customer;
using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework.Internal;
using TrainingUnitTesting;

namespace CustomerTest
{
    public class Tests : BaseTest
    {
        private readonly HttpClient _client;
        private Guid _customerId;

        public Tests()
        {
            _client = GetClient;
        }


        [Test, Order(1)]
        public async Task TestPost()
        {
            //arrange
            var client = _factory.CreateClient();
            var fromBody = new CreateCustomerRequest()
            {
                Name = "Customer ahh",
                Email = "Customerrr@gmail.com"
            };

            //Act
            //var response = await client.GetAsync("api/v1/customer");
            var temp =  new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/v1/customer", temp);

            var content = await response.Content.ReadAsStringAsync();
            var createdCustomer = JsonConvert.DeserializeObject<Customer>(content);
            _customerId = createdCustomer.CustomerID;


            Assert.That(response.IsSuccessStatusCode,Is.True);
        }

        [Test, Order(2)]
        public async Task TestGet()
        {
            //arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("api/v1/customer");

            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test, Order(3)]
        public async Task TestGetByID()
        {
            //arrange
            var client = _factory.CreateClient();
            //Guid id = await GetExistingCustomerId();

            //Act
            var response = await client.GetAsync($"api/v1/customer/{_customerId}");

            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test, Order(4)]
        public async Task TestPut()
        {
            //arrange
            var client = _factory.CreateClient();
            //Guid id = await GetExistingCustomerId();

            var fromBody = new UpdateCustomerDataModel()
            {
               Name = "update1",
               Email = "updateeee@gmail.com"
            };

            //Act
            var temp = new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"api/v1/customer/{_customerId}", temp);

            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test, Order(5)]
        public async Task TestDelete()  
        {
            //arrange
            var client = _factory.CreateClient();
            //Guid id = await GetExistingCustomerId();

            //Act
            var response = await client.DeleteAsync($"api/v1/customer/{_customerId}");

            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}