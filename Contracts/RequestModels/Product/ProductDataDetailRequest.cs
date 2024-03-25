using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class ProductDataDetailRequest : IRequest<ProductDataDetailResponse>
    {
        public Guid ProductId { get; set; }
    }
}
