using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestHandlers.ManageCart
{
    public class UpdateCartHandler: IRequestHandler<UpdateCartRequest,UpdateCartResponse>
    {
        public readonly DBContext _db;
        public UpdateCartHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<UpdateCartResponse> Handle(UpdateCartRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Carts.Where(Q => Q.CartID == request.CartID)
                .Select(Q => Q).FirstOrDefaultAsync();
            if (existingData == null)
            {
                return new UpdateCartResponse
                {
                    Massage = "Failed to update data!"
                };
            }
            if(request.Quantity == 0)
            {
                _db.Carts.Remove(existingData);
                await _db.SaveChangesAsync(cancellationToken);
                return new UpdateCartResponse
                {
                    Massage = "Succesfully to update data and deleted it!"
                };
            }

            existingData.Quantity = request.Quantity;
            await _db.SaveChangesAsync(cancellationToken);

            var response = new UpdateCartResponse
            {
                Massage = "Successfully updated data!"
            };

            return response;
        }
    }
}
