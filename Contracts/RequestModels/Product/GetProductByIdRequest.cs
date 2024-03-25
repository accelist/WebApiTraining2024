using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public Guid? ProductId { get; set; }
    }
}
