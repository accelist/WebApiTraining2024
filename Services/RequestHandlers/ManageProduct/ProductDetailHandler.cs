using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestHandlers.ManageProduct
{
    public class ProductDetailHandler : IRequestHandler<ProductDetailRequest, ProductDetailResponse>
    {
        private readonly DBContext _db;
        public ProductDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<ProductDetailResponse> Handle(ProductDetailRequest request, CancellationToken cancellationToken)
        {
            var result = await _db.Products.Where(Q => Q.ProductID == request.ProductId).Select(Q=> new ProductDetailResponse
            {
                ProductId = Q.ProductID,
                Name = Q.Name,
                Price = Q.Price,
            }).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            if(result == null)
            {
                return new ProductDetailResponse();
            }
            return result;
        }
    }
}
