namespace Contracts.ResponseModels.Product
{
    public class GetProductDataResponse
    {
        public List<ProductData> Products { get; set; } = new List<ProductData>();
    }

    public class ProductData
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty; 
        public decimal ProductPrice { get; set; }
    }
}
