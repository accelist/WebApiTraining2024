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
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly DBContext _db;
        public DeleteProductHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Products.Where(Q => Q.ProductID == request.ProductID)
                .AsNoTracking().FirstOrDefaultAsync();

            if (data == null)
            {
                return new DeleteProductResponse
                {
                    Message = "Data Not Found"
                };
            }
            _db.Products.Remove(data);
            await _db.SaveChangesAsync(cancellationToken);
            var response = new DeleteProductResponse
            {
                Message = "Data Deleted"
            };
            return response;
        }
    }
}
