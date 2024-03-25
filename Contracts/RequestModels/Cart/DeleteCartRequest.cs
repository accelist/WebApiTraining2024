using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class DeleteCartRequest : IRequest<DeleteCartResponse>
    {
        public Guid CartId { get; set; }
    }
}
