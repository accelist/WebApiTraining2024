using Contracts.ResponseModels.Cart;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Cart
{
    public class DeleteCartRequest: IRequest<DeleteCartResponse>
    {
        public Guid CartID { get; set; }
    }
}
