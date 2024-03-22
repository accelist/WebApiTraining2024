
using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class CartDetailRequest : CartDetailModel, IRequest<CartDetailResponse>
    {

    }

    public class CartDetailModel
    {
        public Guid CartId { get; set; }
    }
}
