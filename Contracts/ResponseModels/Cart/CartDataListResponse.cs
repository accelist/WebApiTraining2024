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
        public Guid CustomerId { get; set; }
    }
}
