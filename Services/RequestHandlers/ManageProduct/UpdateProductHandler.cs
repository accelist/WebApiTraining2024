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
    public class UpdateProductHandler: IRequestHandler<UpdateProductRequest,UpdateProductResponse>
    {
        private readonly DBContext _db;

        public UpdateProductHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Products.Where(Q => Q.ProductID == request.ProductID)
                .Select(Q => Q).FirstOrDefaultAsync();

            existingData.Name = request.Name;
            existingData.Price = request.Price;
            await _db.SaveChangesAsync(cancellationToken);

            var response = new UpdateProductResponse
            {
                Massage = "Successfully updated data!"
            };

            return response;
        }
    }
}
