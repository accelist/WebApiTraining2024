using Contracts.ResponseModels.Customer;
using MediatR;

namespace Contracts.RequestModels.Customer
{
    public class DeleteCustomerDataRequest : IRequest<DeleteCustomerDataResponse>
    {
        public Guid? CustomerId { get; set; }
    }
}
