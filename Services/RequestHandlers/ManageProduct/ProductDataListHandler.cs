using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageProduct
{
    public class ProductDataListHandler : IRequestHandler<ProductDataListRequest, ProductDataListResponse>
    {
        private readonly DBContext _db;
        public ProductDataListHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<ProductDataListResponse> Handle(ProductDataListRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Products.Select(Q => new ProductData
            {
                ProductId = Q.ProductId,
                Name = Q.Name,
                Price = Q.Price
            }).AsNoTracking().ToListAsync(cancellationToken);

            var response = new ProductDataListResponse
            {
                datas = data
            };

            return response;
        }  
    }
}
