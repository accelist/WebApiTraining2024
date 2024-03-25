namespace Contracts.ResponseModels.Cart
{
    public class GetCartByIdResponse
    {
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
