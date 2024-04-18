using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.ResponseModels.Cart
{
    public class CustomerCartResponse
    {
        public List<CartData> CartDatas { get; set; } = new List<CartData>();
        public int TotalData { get; set; }
    }

    public class CartData
    {
        public Guid CartID { get; set; }
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
