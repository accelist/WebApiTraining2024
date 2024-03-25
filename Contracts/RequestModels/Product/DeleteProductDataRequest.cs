
using Contracts.ResponseModels.Product;
using MediatR;


namespace Contracts.RequestModels.Product
{
    public class DeleteProductDataRequest : DeleteProductModel, IRequest<DeleteProductDataResponse>
    {
        public Guid ProductID { get; set; }
    }
    public class DeleteProductModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
