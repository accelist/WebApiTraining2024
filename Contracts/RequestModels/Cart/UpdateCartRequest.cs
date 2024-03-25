using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class UpdateCartRequest : UpdateCartModel, IRequest<UpdateCartResponse>
    {
        public Guid? CartId { get; set; }
    }

    public class UpdateCartModel
    {
        public int Quantity { get; set; }
    }
}
