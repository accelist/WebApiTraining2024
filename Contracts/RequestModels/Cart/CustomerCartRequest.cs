using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class CustomerCartRequest : IRequest<CustomerCartResponse>
    {
        public Guid CustomerID { get; set; }
    }
}
