using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;

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
            var data = await _db.Carts.FindAsync(request.CartId);
            if (data == null)
            {
                return new UpdateCartResponse
                {
                    IsSuccess = false,
                    Message = "Cart data not found"
                };
            }
            data.Quantity = request.Quantity;

            _db.Carts.Update(data);
            await _db.SaveChangesAsync();

            return new UpdateCartResponse
            {
                IsSuccess = true,
                Message = "Product quantity updated"
            };
        }
    }
}
