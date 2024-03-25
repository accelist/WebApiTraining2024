using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestHandlers.ManageCart
{
    public class DeleteCartHandler : IRequestHandler<DeleteCartRequest, DeleteCartResponse>
    {
        private readonly DBContext _db;
        public DeleteCartHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DeleteCartResponse> Handle(DeleteCartRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Carts.FindAsync(request.CartID);
            if (existingData == null)
            {
                return new DeleteCartResponse()
                {
                    Success = false,
                    Message = "Data Not Found"
                };
            }
            existingData.CartID = request.CartID;
            existingData.ProductID = request.ProductID;
            existingData.Quantity = request.Quantity;
            existingData.CustomerID = request.CustomerID;
            _db.Carts.Remove(existingData);
            await _db.SaveChangesAsync();

            return new DeleteCartResponse()
            {
                Success = true,
                Message = "Data Deleted"
            };
        }
    }
}
