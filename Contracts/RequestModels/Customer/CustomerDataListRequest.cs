using Contracts.ResponseModels.Customer;
using MediatR;

namespace Contracts.RequestModels.Customer
{
	public class CustomerDataListRequest : CustomerDataModel, IRequest<CustomerDataListResponse>
	{
        public Guid? CustomerID { get; set; }
    }

    public class CustomerDataModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
