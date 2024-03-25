using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class GetCartByIdRequest : GetCartModel, IRequest<GetCartByIdResponse>
    {
        public Guid CartId { get; set; }
    }

    public class GetCartModel
    {

    }
}
