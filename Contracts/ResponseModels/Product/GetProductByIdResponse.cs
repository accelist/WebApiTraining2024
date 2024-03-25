namespace Contracts.ResponseModels.Product
{
    public class GetProductByIdResponse
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
