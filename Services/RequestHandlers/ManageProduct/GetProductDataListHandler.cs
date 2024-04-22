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
            var query = _db.Products.AsQueryable();


            if (!string.IsNullOrEmpty(request.SearchQuery))
            {
                query = query.Where(Q => Q.Name.Contains(request.SearchQuery));
            }

            if (request.PageIndex < 1)
            {
                request.PageIndex = 1;
            }

            if (request.ItemPerPage < 1)
            {
                request.ItemPerPage = 10;
            }

            var datas = await query.Select(Q => new ProductData
            {
                ProductId = Q.ProductID,
                Name = Q.Name,
                Price = Q.Price,
            })
            .AsNoTracking()
            .Skip((request.PageIndex - 1) * request.ItemPerPage)
            .Take(request.ItemPerPage)
            .ToListAsync(cancellationToken);

            var totalData = await query.CountAsync(cancellationToken);

            var response = new ProductDataListResponse
            {
                ProductDatas = datas,
                TotalData = totalData
            };

            return response;
        }
    }
}
