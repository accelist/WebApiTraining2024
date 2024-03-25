using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Customer;
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
    public class UpdateCartDataHandler : IRequestHandler<UpdateCartDataRequest, UpdateCartDataResponse>
    {
        private readonly DBContext _db;
        public UpdateCartDataHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<UpdateCartDataResponse> Handle(UpdateCartDataRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Carts.FindAsync(request.CartID);

            if (existingData == null)
            {
                return new UpdateCartDataResponse()
                {
                    Success = false,
                    Message = "Data Tidak ditemukan"
                };
            }

            existingData.Quantity = request.Quantity;

            _db.Carts.Update(existingData);
            await _db.SaveChangesAsync(cancellationToken);
            return new UpdateCartDataResponse()
            {
                Success = true,
                Message = "Data Updated."
            };
        }


    }
}
