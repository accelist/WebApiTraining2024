using Contracts.ResponseModels.Customer;
using MediatR;

namespace Contracts.RequestModels.Customer 
{
    public class GetCustomerRequest : GetCustomerModel, IRequest<GetCustomerResponse>
    {
        public Guid CustomerId { get; set; }
    }

    public class GetCustomerModel 
    { 

    }

}
