
using Contracts.ResponseModels.Customer;
using MediatR;

namespace Contracts.RequestModels.Customer
{
    public class UpdateCustomerRequest : UpdateCustomerModel, IRequest<UpdateCustomerResponse>
    {
        public Guid CustomerId { get; set; }

    }

    public class UpdateCustomerModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
