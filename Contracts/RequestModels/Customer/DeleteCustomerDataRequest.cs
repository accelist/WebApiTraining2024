using Contracts.ResponseModels.Customer;
using MediatR;

namespace Contracts.RequestModels.Customer
{
    public class DeleteCustomerDataRequest : DeleteCustomerModel, IRequest<DeleteCustomerDataResponse>
    {
        public Guid CustomerId { get; set; }
    }
    public class DeleteCustomerModel
    {
        
    }
}
