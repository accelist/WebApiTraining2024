using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class CreateProductRequest : IRequest<CreateProductResponse> 
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
    }
}
