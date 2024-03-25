using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class GetProductDataRequest : IRequest<GetProductDataResponse>
    {
    }
}
