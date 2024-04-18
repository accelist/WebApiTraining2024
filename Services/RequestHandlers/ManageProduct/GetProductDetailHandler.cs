using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageProduct
{
    public class GetProductDetailHandler : IRequestHandler<ProductDetailRequest, ProductDetailResponse>
    {
        private readonly DBContext _db;

        public GetProductDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<ProductDetailResponse> Handle(ProductDetailRequest request, CancellationToken cancellationToken)
        {
            var response = await _db.Products
                .Where(Q => Q.ProductID == request.ProductID)
                .Select(Q => new ProductDetailResponse
                {
                    ProductID = Q.ProductID,
                    Name = Q.Name,
                    Price = Q.Price,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
