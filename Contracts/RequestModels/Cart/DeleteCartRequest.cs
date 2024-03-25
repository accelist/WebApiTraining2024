using Contracts.ResponseModels.Cart;
using MediatR;


namespace Contracts.RequestModels.Cart
{
    public class DeleteCartRequest : DeleteCartModel, IRequest<DeleteCartResponse>
    {
        public Guid CartID { get; set; }

    }

    public class DeleteCartModel
    {
        public int Quantity { get; set; }
        public Guid CustomerID { get; set; }
        public Guid ProductID { get; set; }
    }
}
