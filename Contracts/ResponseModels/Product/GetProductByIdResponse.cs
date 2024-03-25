namespace Contracts.ResponseModels.Product
{
    public class GetProductByIdResponse
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }   
    }
}
