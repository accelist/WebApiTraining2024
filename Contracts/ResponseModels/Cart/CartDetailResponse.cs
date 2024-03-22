namespace Contracts.ResponseModels.Cart
{
    public class CartDetailResponse
    {
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
    }
}
