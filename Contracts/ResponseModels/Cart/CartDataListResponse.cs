namespace Contracts.ResponseModels.Cart
{
    public class CartDataListResponse
    {
        public List<CartDataModel> Data { get; set; } = [];
    }
    public class CartDataModel
    { 
        public int Quantity { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Subtotal {  get; set; }
        
    }
}
