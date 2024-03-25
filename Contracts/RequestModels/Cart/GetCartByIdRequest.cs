using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class GetCartByIdRequest : IRequest<GetCartByIdResponse>
    {
        public Guid? CartId { get; set; }
        
    }
}
