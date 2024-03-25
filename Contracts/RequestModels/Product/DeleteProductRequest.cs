using Contracts.ResponseModels.Customer;
using Contracts.ResponseModels.Product;
using MediatR;

namespace Services.RequestHandlers.ManageProduct
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public Guid ProductId {  get; set; }
    }
}
