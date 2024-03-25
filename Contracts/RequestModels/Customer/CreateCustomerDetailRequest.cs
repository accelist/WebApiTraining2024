
using Contracts.ResponseModels.Customer;
using MediatR;


namespace Contracts.RequestModels.Customer
{
    public class CreateCustomerDetailRequest : IRequest<CreateCustomerDetailResponse>
    {
        public Guid CustomerID { get; set; }   
    }
}
