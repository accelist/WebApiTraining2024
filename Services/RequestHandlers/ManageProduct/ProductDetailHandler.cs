using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Customer;
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
    public class ProductDetailHandler: IRequestHandler<ProductDetailRequest,ProductDetailResponse>
    {
        public readonly DBContext _db;
        public ProductDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<ProductDetailResponse> Handle(ProductDetailRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Products.Where(Q => Q.ProductID == request.ProductID)
                .Select(Q => new ProductData
                {
                    ProductID = Q.ProductID,
                    Name = Q.Name,
                    Price = Q.Price
                }).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            var result = new ProductDetailResponse
            {
                ProductDetails = data
            };
            return result;
        }
    }
}
