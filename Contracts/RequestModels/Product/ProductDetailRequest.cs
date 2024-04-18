using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class ProductDetailRequest : IRequest<ProductDetailResponse>
    {
        public Guid ProductID { get; set; }
    }
}
