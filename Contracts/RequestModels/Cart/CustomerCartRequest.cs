using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{
    public class CustomerCartRequest : CustomerCartModel, IRequest<CustomerCartResponse>
    {
        public Guid CustomerID { get; set; }   
    }

    public class CustomerCartModel
    {
        public string SearchQuery { get; set; } = string.Empty;
        public int PageIndex { get; set; }
        public int ItemPerPage { get; set; }
    }
}
