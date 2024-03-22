using Contracts.ResponseModels.Cart;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Cart
{
    public class UpdateCartRequest: UpdateCartData,IRequest<UpdateCartResponse>
    {
        public Guid CartID { get; set; }
    }

    public class UpdateCartData
    {
        public int Quantity { get; set; }
        public Guid ProductID { get; set; }
        public Guid CustomerID { get; set; }
    }
}
