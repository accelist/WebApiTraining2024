using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Customer;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Name = request.Name,
                Price = request.Price
            };

            _db.Products.Add(product);
            await _db.SaveChangesAsync(cancellationToken);

            var response = new CreateProductResponse
            {
                ProductID = product.ProductID
            };

            return response;
        }
    }
}
