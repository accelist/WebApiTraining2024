namespace Contracts.ResponseModels.Product
{
    public class ProductDataListResponse
    {
        public List<ProductData> datas { get; set; } = new List<ProductData>();
    }
    public class ProductData
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
