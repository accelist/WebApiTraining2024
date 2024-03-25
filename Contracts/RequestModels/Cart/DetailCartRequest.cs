using Contracts.ResponseModels.Cart;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Cart
{
    public class DetailCartRequest : IRequest<DetailCartResponse>
    {
        public Guid CartID { get; set; }
    }
}
