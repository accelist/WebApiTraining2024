using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class UpdateCartRequest : UpdateCartModel, IRequest<UpdateCartResponse>
    {
        public Guid Id { get; set; }
    }

    public class UpdateCartModel
    {
        public int Quantity { get; set; }
    }
}
