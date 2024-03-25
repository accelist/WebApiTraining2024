using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Customer;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageProduct
{
    internal class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly DBContext _db;
        public UpdateProductHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Products.FindAsync(request.Id);
            if (existingData == null)
            {
                return new UpdateProductResponse()
                {
                    Message = "Product Not Found"
                };
            }
            existingData.Name = request.ProductName;
            existingData.Price = request.Price;

            _db.Products.Update(existingData);
            await _db.SaveChangesAsync(cancellationToken);

            return new UpdateProductResponse()
            {
                Message = "Product Updated."
            };

        }
    }
}
