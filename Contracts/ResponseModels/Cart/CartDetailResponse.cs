namespace Contracts.ResponseModels.Cart
{
    public class CartDetailResponse
    {
        public int Quantity { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
    }
}
