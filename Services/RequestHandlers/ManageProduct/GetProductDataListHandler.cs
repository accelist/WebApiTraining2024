using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageProduct
{
    public class GetProductDataListHandler : IRequestHandler<ProductDataListRequest, ProductDataListResponse>
    {
        private readonly DBContext _db;

        public GetProductDataListHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<ProductDataListResponse> Handle(ProductDataListRequest request, CancellationToken cancellationToken)
        {
            var datas = await _db.Products.Select(Q => new ProductData
            {
                ProductID = Q.ProductID,
                Name = Q.Name,
                Price = Q.Price,
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);

            var response = new ProductDataListResponse
            {
                ProductDatas = datas
            };

            return response;
        }
    }
}
