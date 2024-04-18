using Contracts.ResponseModels.Customer;
using MediatR;

namespace Contracts.RequestModels.Customer
{
	public class CustomerDataListRequest : IRequest<CustomerDataListResponse>
	{
        public string SearchQuery { get; set; } = string.Empty;
        public int PageIndex { get; set; }
        public int ItemPerPage { get; set; }
    }
}
