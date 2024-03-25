using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class UpdateProductDataRequest : UpdateProductModel, IRequest<UpdateProductDataResponse>
    {
        public Guid? Id { get; set; }
    }

    public class UpdateProductModel
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
    }
}
