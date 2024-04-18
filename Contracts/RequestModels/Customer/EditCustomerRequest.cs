using MediatR;

namespace Contracts.RequestModels.Customer
{
    public class EditCustomerRequest : EditCustomerModel, IRequest<bool>
    {
        public Guid CustomerID { get; set; }
    }

    public class EditCustomerModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
