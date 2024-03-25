using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace TrainingUnitTesting
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
        public async Task TestCreateCustomerData()
        {

            var client = _factory.CreateClient();
            var fromBody = new CreateCustomerRequest()
            {
                Name = "Customer 2",
                Email = "Customer2@gmail.com"
            };

            // var response = await client.GetAsync("api/v1/customer");
            var response = await client.PostAsync("api/v1/customer", new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json"));

             //Assert / validator
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test]
        public async Task TestGetCustomerDataList()
        {
            var client = _factory.CreateClient();
            // var response = await client.GetAsync("api/v1/customer");
            var response = await client.GetAsync("api/v1/customer");

            //Assert / validator
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test]
        public async Task TestGetCustomerDetail()
        {
            // Arrange
            var customerId = "9b457ed6-f864-43e7-b62b-5ba3d6bfcdad"; 
            var client = _factory.CreateClient();

           var response = await client.GetAsync($"api/v1/customer/{customerId}");

            // Assert 
            Assert.That(response.IsSuccessStatusCode, Is.True);  // HTTP Status Code Check

            var content = await response.Content.ReadAsStringAsync();
            var customerDetail = JsonConvert.DeserializeObject<CreateCustomerDetailResponse>(content);

            Assert.That(customerDetail.Name, Is.Not.Null.Or.Empty);
            Assert.That(customerDetail.Email, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task TestDeleteCustomerData()
        {
            // Arrange 
            var customerId = "5eefc3da-7647-432f-bbf9-182b8f060cca"; // Or the ID of a customer you create specifically for deletion

            var client = _factory.CreateClient();

            // Act 
            var response = await client.DeleteAsync($"api/v1/customer/{customerId}");

            // Assert 
            Assert.That(response.IsSuccessStatusCode, Is.True);  // HTTP Status Code Check 

        }

        [Test]
        public async Task TestUpdateCustomerData()
        {
            // Arrange
            var customerId = "9b457ed6-f864-43e7-b62b-5ba3d6bfcdad"; // Replace with an existing customer ID 
            var updatedName = "Updated Customer Name";
            var updatedEmail = "updated@email.com";

            var client = _factory.CreateClient();
            var requestBody = new UpdateCustomerDataRequest
            {
                // CustomerId is not included in the request body anymore
                Name = updatedName,
                Email = updatedEmail
            };

            // Act - Updated to include CustomerId in the URL
            var response = await client.PutAsync($"api/v1/customer/{customerId}",
                                  new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json"));

            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);

            // ... (Rest of your assertions)
        }
    
    }
}