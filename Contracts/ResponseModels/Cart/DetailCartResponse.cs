using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ResponseModels.Cart
{
    public class DetailCartResponse
    {
        public Guid CartID { get; set; }
        public int Quantity { get; set; }
        public Guid ProductID { get; set; }
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal SubTotal { get; set; }
    }
}
