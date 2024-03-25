using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class DeleteCartRequest: DeleteCartModel, IRequest<DeleteCartResponse>
    {
        public Guid Id { get; set; }
    }

    public class DeleteCartModel
    {

    }
}
