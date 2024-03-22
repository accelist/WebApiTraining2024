using Contracts.ResponseModels.Cart;
using MediatR;
namespace Contracts.RequestModels.Cart
{
    public class DeleteCartRequest : DeleteCartModel, IRequest<DeleteCartResponse>
    {

    }

    public class DeleteCartModel
    {
        public Guid CartId { get; set; }
    }
}
