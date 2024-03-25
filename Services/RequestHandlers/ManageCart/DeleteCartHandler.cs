
using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
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
            var selectedData = await _db.Carts.Where(Q=>Q.CartID ==  request.CartId).Select(Q=>Q).FirstOrDefaultAsync(cancellationToken);
            if (selectedData == null)
            {
                return new DeleteCartResponse()
                {
                    IsSuccess = false,
                    Message = "CartID does not exist."
                };
            }
            _db.Remove(selectedData);
            await _db.SaveChangesAsync(cancellationToken);
            return new DeleteCartResponse()
            {
                IsSuccess = true,
                Message = "Cart successfully deleted."
            };
        }
    }
}
