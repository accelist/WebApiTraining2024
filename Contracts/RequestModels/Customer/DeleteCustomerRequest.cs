using Contracts.ResponseModels.Customer;
using MediatR;

namespace Contracts.RequestModels.Customer
{
    public class DeleteCustomerRequest : DeleteCustomerModel, IRequest<DeleteCustomerResponse>
    {

    }

    public class DeleteCustomerModel
    {
        public Guid CustomerID { get; set; }
    }
}
