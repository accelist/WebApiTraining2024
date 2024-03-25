using Contracts.ResponseModels.Product;

namespace Contracts.ResponseModels.Cart
{
    public class CartDataListResponse
    {
        public List<CartData> Datas { get; set; } = new List<CartData>();
    }

    public class CartData
    {
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal SubTotal { get; set; }
    }
}
