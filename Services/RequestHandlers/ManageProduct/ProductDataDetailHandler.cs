using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageProduct
{
    public class ProductDataDetailHandler : IRequestHandler<ProductDataDetailRequest, ProductDataDetailResponse>
    {
        private readonly DBContext _db;

        public ProductDataDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<ProductDataDetailResponse> Handle(ProductDataDetailRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Products.FindAsync(request.ProductId);

            var response = new ProductDataDetailResponse()
            {
                ProductId = data.ProductId,
                Price = data.Price,
                Name = data.Name
            };
            return response;
        }
    }
}
