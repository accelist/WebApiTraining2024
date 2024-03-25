
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace UnitTest1
{
    public class ProductControllerTest : BaseTest
    {
        private readonly HttpClient _client;
        public ProductControllerTest()
        {
            _client = GetClient;
        }
        [SetUp]
        public void Setup()
        {
        }

        private Guid testProductId;
        private readonly string url = "api/v1/product";

        [Test, Order(1)]
        public async Task TestPost()
        {
            //Arrange
            var client = _factory.CreateClient();

            var product = new CreateProductRequest
            {
                Name = "Elephant",
                Price = 10000000
            };


            //Act
            var stringContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, stringContent);
            var responseContent = await response.Content.ReadFromJsonAsync<CreateProductResponse>();
            if(responseContent != null)
            {
                testProductId = responseContent.ProductId;
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
            var response = await client.GetAsync($"{url}/{testProductId}");


            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test, Order(4)]
        public async Task TestPut()
        {
            //Arrange
            var client = _factory.CreateClient();
            var product = new UpdateProductModel
            {
                Name = "Badonkadonks",
                Price = 999999999999
            };

            //Act
            var stringContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{url}/{testProductId}", stringContent);

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
            var response = await client.DeleteAsync($"{url}/{testProductId}");

            //assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }
    }
}
