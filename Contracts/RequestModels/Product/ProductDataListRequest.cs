using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class ProductDataListRequest : IRequest<ProductDataListResponse>
    {
        public string? SearchQuery { get; set; }
        public int PageIndex { get; set; }
        public int ItemPerPage { get; set; }
    }
}
