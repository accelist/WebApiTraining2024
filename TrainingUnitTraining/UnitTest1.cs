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

        [Test]
        public async Task Test1()
        {
            //Arrange
            var client = _factory.CreateClient();
            var fromBody = new CreateCustomerRequest
            {
                Name = "customer 1",
                Email = "customer@email.com"
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
    }
}