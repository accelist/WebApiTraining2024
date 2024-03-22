using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ResponseModels.Cart
{
    public class CartDataListResponse
    {
        public List<CartData> CartDatas { get; set; } = new List<CartData>();
    }

    public class CartData
    {
        public Guid CartID { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}
