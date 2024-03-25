using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ResponseModels.Cart
{
    public class GetCartDataListResponse
    {
        public List<CartData> Cartdatas { get; set; } = new List<CartData>();
    }

    public class CartData()
    {
        public Guid CartId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal { get; set; }
    }
}
