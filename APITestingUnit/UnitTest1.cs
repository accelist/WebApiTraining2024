using Contracts.RequestModels.Customer;
using Newtonsoft.Json;
using System.Text;

namespace APITestingUnit
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
            var client = _factory.CreateClient();
            /*var product = new Product
            {
                ProductID = Guid.NewGuid(),
                Name = "Product 1",
                Price = 10000
            };*/

            var fromBody = new CreateCustomerRequest
            {
                Email = "jemynathanael0821@gmail.com",
                Name = "Jemy Nathanael"
            };

            var requestBody = new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/v1/customer", requestBody);

            //var response = await client.GetAsync("api/v1/customer");
            //var response = await client.PostAsync("api/v1/customer", new StringContent(JsonConvert.SerializeObject(fromBody), Encoding.UTF8, "");

            Assert.That(response.IsSuccessStatusCode, Is.False);
            Assert.Pass();
        }

        public async Task TestGet()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/v1/customer");
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}