using Contracts.RequestModels.Cart;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCart
{
    public class CreateUpdateCustomerCartHandler : IRequestHandler<CreateUpdateCustomerCartRequest, bool>
    {
        private readonly DBContext _db;

        public CreateUpdateCustomerCartHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(CreateUpdateCustomerCartRequest request, CancellationToken cancellationToken)
        {
            var existingCart = await _db.Carts
                                    .Where(Q => Q.ProductID == request.ProductID && Q.CustomerID == request.CustomerID)
                                    .Select(Q => Q)
                                    .FirstOrDefaultAsync(cancellationToken);
            if (existingCart == null)
            {
                var cart = new Cart
                {
                    CartID = Guid.NewGuid(),
                    ProductID = request.ProductID,
                    CustomerID = request.CustomerID,
                    Quantity = request.Quantity
                };

                _db.Carts.Add(cart);
            }
            else
            {
                existingCart.Quantity = request.Quantity;
            }
            
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
