using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class UpdateCartDataRequest : UpdateDataModel, IRequest<UpdateCartDataResponse>
    {
        public Guid CartId { get; set; }
    }

    public class UpdateDataModel
    {
        public int Quantity { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
