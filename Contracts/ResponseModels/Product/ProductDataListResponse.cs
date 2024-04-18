namespace Contracts.ResponseModels.Product
{
    public class ProductDataListResponse
    {
        public List<ProductData> ProductDatas { get; set; } = new List<ProductData>();
        public int TotalData { get; set; }
    }

    public class ProductData
    {
        public Guid ProductID { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
