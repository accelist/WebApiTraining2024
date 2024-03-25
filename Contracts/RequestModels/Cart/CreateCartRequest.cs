using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class CreateCartRequest : IRequest<CreateCartResponse>
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid Customerid { get; set; }
    }
}
