namespace Contracts.ResponseModels.Cart
{
    public class GetCartResponse
    {
        public List<CartData> CartDatas { get; set; } = new List<CartData>();
    }

    public class CartData
    {
        public Guid? CartId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
