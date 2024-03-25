using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class DeleteCartDataRequest : DeleteCartModel, IRequest<DeleteCartDataResponse>
    {
        public Guid CartId { get; set; }

    }

    public class DeleteCartModel
    {
        public int Quantity { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
