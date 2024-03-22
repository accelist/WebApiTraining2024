namespace Contracts.ResponseModels.Cart
{
    public class CartDataListResponse
    {
        public List<CartDataModel> Data { get; set; } = [];
    }
    public class CartDataModel
    {
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
    }
}
