using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Entity.Entity;
using Newtonsoft.Json;
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

        [Test]
        public async Task Test1()
        {
            //Arrange
            var client = _factory.CreateClient();
            //var product = new CreateProductRequest()
            //{
            //    Name = "Test1",
            //    Price = 100000,
            //};
            var customer = new CreateCustomerRequest
            {
                Name = "TestName",
                Email = "TestEmail@gmail.com"
            };



            //Act
            //var response = await client.GetAsync("api/v1/product");
            var stringContent = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/v1/customer", stringContent);


            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }
    }
}