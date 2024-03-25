using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageCart
{
    public class UpdateProductHandler : IRequestHandler<UpdateCartRequest, UpdateCartResponse>
    {
        private readonly DBContext _db;
        public UpdateProductHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<UpdateCartResponse> Handle(UpdateCartRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Carts.FindAsync(request.Id);
            
            if (existingData == null)
            {
                return new UpdateCartResponse()
                {
                    Message = "Update failed. Cart Not Found"
                };
            }

            if (request.Quantity <= 0)
            {
                _db.Carts.Remove(existingData);
                await _db.SaveChangesAsync(cancellationToken);

                return new UpdateCartResponse()
                {
                    Message = "Cart Removed."
                };
            }

            existingData.Quantity = request.Quantity;

            _db.Carts.Update(existingData);
            await _db.SaveChangesAsync(cancellationToken);
            return new UpdateCartResponse()
            {
                Message = "Cart Updated."
            };
        }
    }
}
