using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Customer;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestHandlers.ManageProduct
{
    public class UpdateProductDataListHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly DBContext _db;
        public UpdateProductDataListHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Products.FindAsync(request.ProductID);
            if (existingData == null)
            {
                return new UpdateProductResponse()
                {
                    Success = false,
                    Message = "Data Not Found"
                };
            }
            existingData.Name = request.Name;
            existingData.Price = request.Price;
            _db.Products.Update(existingData);
            await _db.SaveChangesAsync(cancellationToken);
            return new UpdateProductResponse()
            {
                Success = true,
                Message = "Data Updated"
            };
        }
    }
}
