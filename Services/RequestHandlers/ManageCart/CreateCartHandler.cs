using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Services.RequestHandlers.ManageCart
{
    public class CreateCartHandler : IRequestHandler<CreateCartRequest, CreateCartResponse>
    {
        private readonly DBContext _db;

        public CreateCartHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CreateCartResponse> Handle(CreateCartRequest request, CancellationToken cancellationToken)
        {
            var cart = new Cart
            {
                CartID = Guid.NewGuid(),
                CustomerID = request.CustomerID,
                ProductID = request.ProductID,
                Quantity = request.Quantity,
            };

            _db.Carts.Add(cart);
            await _db.SaveChangesAsync(cancellationToken);

            // Load the cart from the database with Customer and Product included
            cart = _db.Carts.Include(c => c.Customer).Include(c => c.Product).Single(c => c.CartID == cart.CartID);

            var response = new CreateCartResponse
            {
                CartID = cart.CartID,
                CustomerName = cart.Customer?.Name,
                ProductName = cart.Product?.Name,
                Price = (decimal)(cart.Product?.Price),
                Quantity = cart.Quantity,
                SubTotal = (decimal)(cart.Product?.Price * cart.Quantity)
            };

            return response;
        }
    }
}
