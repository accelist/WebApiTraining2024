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
    public class UpdateProductDataHandler : IRequestHandler<UpdateProductDataRequest, UpdateProductDataResponse>
    {
        private readonly DBContext _db;
        public UpdateProductDataHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<UpdateProductDataResponse> Handle(UpdateProductDataRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Products.FindAsync(request.ProductID);
            if (existingData == null)
            {
                return new UpdateProductDataResponse()
                {
                    Success = false,
                    Message = "Data Tidak ditemukan"
                };
            }
            existingData.Name = request.Name;
            existingData.Price = request.Price;
            _db.Products.Update(existingData);
            await _db.SaveChangesAsync(cancellationToken);
            return new UpdateProductDataResponse()
            {
                Success = true,
                Message = "Data Updated."
            };

        }

    }
}
