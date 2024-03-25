using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;

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
            var data = new Cart
            {
                CartID = Guid.NewGuid(),
                CustomerID = request.CustomerId,
                ProductID = request.ProductId,
                Quantity = request.Quantity
            };

            _db.Carts.Add(data);
            await _db.SaveChangesAsync();

            var response = new CreateCartResponse
            {
                CartId = data.CartID
            };

            return response;
        }
    }
}
