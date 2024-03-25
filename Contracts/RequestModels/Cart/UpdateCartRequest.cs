using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Cart
{
    public class UpdateCartRequest : UpdateCartModel, IRequest<UpdateCartResponse>
    {
        public Guid? CartID { get; set; }

    }
    public class UpdateCartModel
    {
        //public Guid ProductID { get; set; }
        //public Guid CustomerID { get; set; }
        public int Quantity { get; set; }
    }
}
