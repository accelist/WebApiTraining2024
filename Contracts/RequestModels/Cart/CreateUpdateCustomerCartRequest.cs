using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class CreateUpdateCustomerCartRequest : IRequest<bool>
    {
        public Guid ProductID { get; set; }
        public Guid CustomerID { get; set; }
        public int Quantity { get; set; }
    }
}
