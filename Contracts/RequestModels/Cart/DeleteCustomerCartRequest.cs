using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class DeleteCustomerCartRequest : IRequest<bool>
    {
        public Guid CartID { get; set; }
    }
}
