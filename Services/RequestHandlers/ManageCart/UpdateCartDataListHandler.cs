using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestHandlers.ManageCart
{
    public class UpdateCartDataListHandler : IRequestHandler<UpdateCartRequest, UpdateCartResponse>
    {
        private readonly DBContext _db;
        public UpdateCartDataListHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<UpdateCartResponse> Handle(UpdateCartRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Carts.FindAsync(request.CartID);
            if (existingData == null)
            {
                return new UpdateCartResponse()
                {
                    Success = false,
                    Message = "Data Not Found"
                };
            }

            if (request.Quantity == 0)
            {
                _db.Carts.Remove(existingData);
                await _db.SaveChangesAsync(cancellationToken);
                return new UpdateCartResponse()
                {
                    Success = true,
                    Message = "Data Removed"
                };
            }
            else
            {
                existingData.Quantity = request.Quantity;
                _db.Carts.Update(existingData);
                await _db.SaveChangesAsync(cancellationToken);
                return new UpdateCartResponse()
                {
                    Success = true,
                    Message = "Data Updated"
                };
            }
            //existingData.Quantity = request.Quantity;
            //existingData.ProductID = request.ProductID;
            //existingData.CustomerID = request.CustomerID;
            //_db.Carts.Update(existingData);
        }
    }
}
