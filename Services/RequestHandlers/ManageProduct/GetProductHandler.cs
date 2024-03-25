using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageProduct
{
    public class GetProductHandler : IRequestHandler<GetProductDataRequest, GetProductDataResponse>
    {
        private readonly DBContext _db;
        public GetProductHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<GetProductDataResponse> Handle(GetProductDataRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Products.Select(Q => new ProductData
            {
                ProductId = Q.ProductID,
                ProductName = Q.Name,
                ProductPrice = Q.Price
            }).AsNoTracking().ToListAsync();

            var response = new GetProductDataResponse
            {
                Products = data,
            };

            return response;
        }
    }
}
