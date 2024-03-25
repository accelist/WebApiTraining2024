using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageCart
{
    public class CreateCarthandler : IRequestHandler<CreateCartRequest, CreateCartResponse>
    {
        private readonly DBContext _db;
        public CreateCarthandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CreateCartResponse> Handle(CreateCartRequest request,CancellationToken cancellationToken)
        {
            var cart = new Cart
            {
                CartId = Guid.NewGuid(),
                Quantity = request.Quantity,
                ProductId = request.ProductId,
                CustomerId = request.Customerid
            };
            _db.Carts.Add(cart);
            await _db.SaveChangesAsync();

            var responses = new CreateCartResponse
            {
                CartId = cart.CartId,
            };

            return responses;
        }
    }
}
