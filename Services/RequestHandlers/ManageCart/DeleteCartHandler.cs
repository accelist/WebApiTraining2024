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
    public class DeleteCartHandler : IRequestHandler<DeleteCartRequest, DeleteCartResponse>
    {
        private readonly DBContext _db;
        public DeleteCartHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DeleteCartResponse> Handle(DeleteCartRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Carts.Where(Q => Q.CartID == request.CartID)
                .AsNoTracking().FirstOrDefaultAsync();

            if (data == null)
            {
                return new DeleteCartResponse
                {
                    Message = "Data Not Found"
                };
            }
            _db.Carts.Remove(data);
            await _db.SaveChangesAsync(cancellationToken);
            var response = new DeleteCartResponse
            {
                Message = "Data Deleted"
            };
            return response;
        }
    }
}
