using MediatR;

namespace Contracts.RequestModels.Customer
{
    public class DeleteCustomerRequest : IRequest<bool>
    {
        public Guid CustomerID { get; set; }
    }
}
