using Contracts.ResponseModels.Customer;
using MediatR;

namespace Contracts.RequestModels.Customer
{
    public class GetCustomerDataByIdRequest : IRequest<GetCustomerDataByIdResponse>
    {
        public Guid? CustomerId { get; set; }
    }

    
}
