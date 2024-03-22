using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Product;
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
    public class DeleteCartHandler: IRequestHandler<DeleteCartRequest,DeleteCartResponse>
    {
        public readonly DBContext _db;
        public DeleteCartHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DeleteCartResponse> Handle(DeleteCartRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Carts.Where(Q => Q.CartID == request.CartID)
                .Select(Q => Q).AsNoTracking().FirstOrDefaultAsync();
            if (data == null)
            {
                return new DeleteCartResponse
                {
                    Massage = "Failed to delete data!"
                };
            }

            _db.Carts.Remove(data);
            await _db.SaveChangesAsync();
            return new DeleteCartResponse
            {
                Massage = "Successfully deleted data!"
            };
        }
    }
}
