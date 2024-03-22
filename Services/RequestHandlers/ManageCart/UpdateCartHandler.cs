using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace Services.RequestHandlers.ManageCart
{
    public class UpdateCartHandler : IRequestHandler<UpdateCartRequest, UpdateCartResponse>
    {
        private readonly DBContext _db;
        public UpdateCartHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<UpdateCartResponse> Handle(UpdateCartRequest request, CancellationToken cancellationToken)
        {
            var selectedData = await _db.Carts.Where(Q=> Q.CartID == request.CartId).Select(Q=>Q).FirstOrDefaultAsync(cancellationToken);
            if (selectedData == null)
            {
                return new UpdateCartResponse()
                {
                    IsSuccess = false,
                    Quantity = 0,
                    Message = "CartID does not exist."
                };
            }
            string message = string.Empty;
            if(request.Quantity <= 0)
            {
                _db.Carts.Remove(selectedData);
                message = "Cart has been succefully removed.";
            }
            else
            {
                selectedData.Quantity = request.Quantity;
                message = "Product quanitity successfully updated.";
            }
            
            await _db.SaveChangesAsync(cancellationToken);
            return new UpdateCartResponse
            {
                IsSuccess = true,
                Quantity = request.Quantity,
                Message = message
            };

        }
    }
}
