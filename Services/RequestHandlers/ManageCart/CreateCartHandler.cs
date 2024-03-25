
using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageCart
{
    public class CreateCartHandler : IRequestHandler<CreateCartRequest ,CreateCartResponse>
    {
        private readonly DBContext _db;

        public CreateCartHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CreateCartResponse> Handle(CreateCartRequest request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FindAsync(request.ProductId);
            var customer = await _db.Customers.FindAsync(request.CustomerId);

            if (product == null || customer == null)
            {
                throw new ArgumentException("Product or Customer not found.");
            }

            var newCart = new Cart
            {
                ProductID = request.ProductId,
                CustomerID = request.CustomerId,
                Quantity = request.Quantity
            };

            _db.Carts.Add(newCart);
            await _db.SaveChangesAsync(cancellationToken);

            var response = new CreateCartResponse
            {
                CartID = newCart.CartID
            };

            return response;
        }
    }
}
