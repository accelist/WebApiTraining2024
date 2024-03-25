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
using Microsoft.EntityFrameworkCore;

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
            var existingData = await _db.Carts.Where(Q => Q.CartID == request.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (existingData == null) 
            {
                return new DeleteCartResponse
                {
                    Message = "Delete failed, Data not found"
                };
            }

            _db.Carts.Remove(existingData);
            await _db.SaveChangesAsync(cancellationToken);
            return new DeleteCartResponse
            {
                Message = "Delete Success"
            };
        }
    }
}
