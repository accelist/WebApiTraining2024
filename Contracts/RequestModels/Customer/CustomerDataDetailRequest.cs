using Contracts.ResponseModels.Customer;
using MediatR;

namespace Contracts.RequestModels.Customer
{
    public class CustomerDataDetailRequest : IRequest<CustomerDataDetailResponse>
    {
        public Guid CustomerId { get; set; }
    }
}
