using Contracts.ResponseModels.Customer;
using MediatR;

namespace Contracts.RequestModels.Customer
{
    public class CustomerDetailRequest : CustomerDetailModel, IRequest<CustomerDetailResponse>
    {

    }
    public class CustomerDetailModel
    {
        public Guid CustomerID { get; set; }
    }
}
