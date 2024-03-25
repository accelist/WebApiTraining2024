using Contracts.ResponseModels.Cart;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Cart
{
    //get -> customerName, productName, price, quantity, subtotal.
    public class UpdateCartDataRequest : UpdateCartDataModel, IRequest<UpdateCartDataResponse>
    {
        public Guid CartID { get; set; }
        //public Guid CustomerID { get; set; }
        //public Guid ProductID { get; set; }
    }

    public class UpdateCartDataModel
    {
        //public string CustomerName { get; set; } = string.Empty;
        //public string ProductName { get ; set; } = string.Empty;
        //public decimal Price { get; set; }
        public int Quantity { get; set; }
        //public Guid CustomerID { get; set; }
        //public Guid ProductID { get; set; }
        //public decimal SubTotal { get; set; }
    }
}
