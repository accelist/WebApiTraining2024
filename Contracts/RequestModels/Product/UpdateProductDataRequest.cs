using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class UpdateProductDataRequest : UpdateProductModel, IRequest<UpdateProductDataResponse>
    {
        public Guid ProductId { get; set; }
    }

    public class UpdateProductModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
