
using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class GetProductByIdRequest : GetProductModel, IRequest<GetProductByIdResponse>
    {
        public Guid ProductId { get; set; }
    }

    public class GetProductModel
    {

    } 
}
