using MediatR;

namespace Contracts.RequestModels.Product
{
    public class DeleteProductRequest : IRequest<bool>
    {
        public Guid ProductID { get; set; }
    }
}
