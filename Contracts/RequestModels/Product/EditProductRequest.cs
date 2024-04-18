using MediatR;

namespace Contracts.RequestModels.Product
{
    public class EditProductRequest : EditProductModel, IRequest<bool>
    {
        public Guid ProductID { get; set; }
    }

    public class EditProductModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
