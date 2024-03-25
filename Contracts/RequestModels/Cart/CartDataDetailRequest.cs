using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class CartDataDetailRequest : IRequest<CartDataDetailResponse>
    {
        public Guid CartId { get; set; }
    }
}
