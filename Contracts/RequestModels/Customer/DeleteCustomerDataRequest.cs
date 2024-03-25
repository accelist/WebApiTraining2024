using Contracts.ResponseModels.Customer;
using MediatR;


namespace Contracts.RequestModels.Customer
{
    public class DeleteCustomerDataRequest : DeleteCustomerModel, IRequest<DeleteCustomerDataResponse>
    {
        public Guid CustomerID { get; set; }
    }
    public class DeleteCustomerModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
