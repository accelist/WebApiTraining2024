using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly DBContext _db;
        public CreateProductHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var data = new Product
            {
                ProductID = Guid.NewGuid(),
                Name = request.ProductName,
                Price = request.ProductPrice
            };

            _db.Products.Add(data);
            await _db.SaveChangesAsync();

            var newId = new CreateProductResponse
            {
                ProductId = data.ProductID
            };

            return newId;
        }
    }
}
