using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var product = new Product
            {
                ProductID = Guid.NewGuid(),
                Name = request.ProductName,
                Price = request.Price,
            };

            _db.Products.Add(product);
            await _db.SaveChangesAsync(cancellationToken);

            var response = new CreateProductResponse
            {
                ProductId = product.ProductID
            };

            return response;
        }
    }
}
