using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Customer;
using Contracts.ResponseModels.Product;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace UnitTest1
{
    public class CartControllerTest : BaseTest
    {
        private readonly HttpClient _client;
        public CartControllerTest()
        {
            _client = GetClient;
        }
        [SetUp]
        public void Setup()
        {
        }

        private readonly string Url = "api/v1/cart";
        private Guid TestCartId;
        private Guid TestCartIdDeleteByPut;
        private Guid TestCustomerId;
        private Guid TestProductId;

        [Test, Order(0)]
        public async Task TestCustomerPost()
        {
            //Arrange
            var client = _factory.CreateClient();

            var customer = new CreateCustomerRequest
            {
                Name = "Bob",
                Email = "cartTester@gmail.com"
            };


            //Act
            var stringContent = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/v1/customer", stringContent);
            CreateCustomerResponse? responseContent = await response.Content.ReadFromJsonAsync<CreateCustomerResponse>();
            if(responseContent != null)
            {
                TestCustomerId = responseContent.CustomerID;
            }

            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test, Order(1)]
        public async Task TestProductPost()
        {
            //Arrange
            var client = _factory.CreateClient();

            var product = new CreateProductRequest
            {
                Name = "Missile Launcher",
                Price = 1375100000
            };

            //Act
            var stringContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/v1/product", stringContent);
            var responseContent = await response.Content.ReadFromJsonAsync<CreateProductResponse>();
            if(responseContent != null)
            {
                TestProductId = responseContent.ProductId;
            }
            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test, Order(2)]
        public async Task TestPost()
        {
            //Arrange
            var client = _factory.CreateClient();

            var cart = new CreateCartRequest
            {
                Quantity = 10,
                CustomerID = TestCustomerId,
                ProductID = TestProductId,
            };


            //act
            var stringContent = new StringContent(JsonConvert.SerializeObject(cart), Encoding.UTF8, "application/json");
            var stringContent2 = new StringContent(JsonConvert.SerializeObject(cart), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(Url, stringContent);
            var responseContent = await response.Content.ReadFromJsonAsync<CreateCartResponse>();
            if (responseContent != null)
            {
                TestCartId = responseContent.CartId;
            }
            var response2 = await client.PostAsync(Url, stringContent2);
            var responseContent2 = await response2.Content.ReadFromJsonAsync<CreateCartResponse>();
            if(responseContent2 != null)
            {
                TestCartIdDeleteByPut = responseContent2.CartId;
            }
            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.That(response2.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }
        [Test, Order(3)]
        public async Task TestGet()
        {
            //Arrange
            var client = _factory.CreateClient();


            //Act
            var response = await client.GetAsync(Url);


            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }
        [Test, Order(4)]
        public async Task TestGetDetail()
        {
            //Arrange
            var client = _factory.CreateClient();


            //Act
            var response = await client.GetAsync($"{Url}/{TestCartId}");


            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test, Order(5)]
        public async Task TestPut()
        {
            //Arrange
            var client = _factory.CreateClient();
            var cart = new UpdateCartModel
            {
                Quantity = 7
            };
            var cartDeleteByPut = new UpdateCartModel
            {
                Quantity = 0
            };

            //Act
            var stringContent = new StringContent(JsonConvert.SerializeObject(cart), Encoding.UTF8, "application/json");
            var stringContentDeleteByPut = new StringContent(JsonConvert.SerializeObject(cartDeleteByPut), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{Url}/{TestCartId}", stringContent);
            var responseDeleteByPut = await client.PutAsync($"{Url}/{TestCartIdDeleteByPut}", stringContentDeleteByPut);

            //Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.That(responseDeleteByPut.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }

        [Test, Order(6)]
        public async Task TestDelete()
        {
            //arrange
            var client = _factory.CreateClient();

            //act
            var response = await client.DeleteAsync($"{Url}/{TestCartId}");
            var responseCustomer = await client.DeleteAsync($"api/v1/customer/{TestCustomerId}");
            var responseProduct = await client.DeleteAsync($"api/v1/product/{TestProductId}");

            //assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.That(responseCustomer.IsSuccessStatusCode, Is.True);
            Assert.That(responseProduct.IsSuccessStatusCode, Is.True);
            Assert.Pass();
        }
    }
}
