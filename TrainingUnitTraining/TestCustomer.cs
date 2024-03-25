using Contracts.RequestModels.Customer;
using Entity.Entity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using NUnit.Framework.Internal;
using System.Runtime.InteropServices;
using System.Text;

namespace TrainingUnitTraining
{
    public class TestCustomer : BaseTest
    {
        private readonly HttpClient _client;
        public TestCustomer()
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
            var fromBody = new CreateCustomerRequest
            {
                Name = "customer 3",
                Email = "customer3@email.com"
            };

            //Act
            var temp = new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/v1/customer", temp);

            /*try
            {
                var response = await client.PostAsync("api/v1/customer", temp);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/

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
            var response = await client.GetAsync("api/v1/customer");
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
            var id = "3f1584c6-dd13-4beb-bad4-69c9167a0241";
            //Assert
            var response = await client.GetAsync("api/v1/customer"+"/"+id);

            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test]
        [Ignore("ignore")]
        public async Task TestPut()
        {
            //Arrange
            var client = _factory.CreateClient();
            var fromBody = new UpdateCustomerRequest
            {
                Name = "customer edit",
                Email = "customer||edit@email.com"
            };
            var temp = new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");
            var id = "59eceb66-63a0-4f37-91da-43fb7abdf434";
            //Act
            var response = await client.PutAsync("api/v1/customer"+"/"+id,temp);
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
            var id = "e9aca685-400d-4765-9426-9d22d04946e1";
            //Assert
            var response = await client.DeleteAsync("api/v1/customer" + "/" + id);

            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }
    }
}