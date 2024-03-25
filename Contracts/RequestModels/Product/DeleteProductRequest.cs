using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class DeleteProductRequest : DeleteProductModel, IRequest<DeleteProductResponse>
    {

    }
    
    public class DeleteProductModel
    {
        public Guid ProductId { get; set; }
    }
}
