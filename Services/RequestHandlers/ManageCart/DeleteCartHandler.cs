using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;

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
            var data = await _db.Carts.FindAsync(request.CartId);
            if (data == null)
            {
                return new DeleteCartResponse
                {
                    IsSuccess = false,
                    Message = "Cart data not found"
                };
            }

            _db.Carts.Remove(data);
            await _db.SaveChangesAsync();

            return new DeleteCartResponse
            {
                IsSuccess = true,
                Message = "Cart data have been deleted successfully"
            };
        }
    }
}
