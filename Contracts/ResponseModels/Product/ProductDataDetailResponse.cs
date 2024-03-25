namespace Contracts.ResponseModels.Product
{
    public class ProductDataDetailResponse
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
