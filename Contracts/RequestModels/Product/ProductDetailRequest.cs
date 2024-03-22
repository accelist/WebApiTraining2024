
using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class ProductDetailRequest : ProductDetailModel, IRequest<ProductDetailResponse>
    {

    }

    public class ProductDetailModel
    {
        public Guid ProductId { get; set; }
    }
}
