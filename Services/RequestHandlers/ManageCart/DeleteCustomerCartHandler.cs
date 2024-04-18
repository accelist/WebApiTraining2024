using Contracts.RequestModels.Cart;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCart
{
    public class DeleteCustomerCartHandler : IRequestHandler<DeleteCustomerCartRequest, bool>
    {
        private readonly DBContext _db;

        public DeleteCustomerCartHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(DeleteCustomerCartRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Carts
                .Where(Q => Q.CartID == request.CartID)
                .Select(Q => Q)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (data == null)
            {
                return false;
            }

            _db.Carts.Remove(data);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
