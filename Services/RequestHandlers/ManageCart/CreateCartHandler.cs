using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Quantity = request.Quantity,
                ProductID = request.ProductID,
                CustomerID = request.CustomerID,
            };

            _db.Carts.Add(cart);
            await _db.SaveChangesAsync(cancellationToken);

            var response = new CreateCartResponse
            {
                CartID = cart.CartID
            };

            return response;
        }
    }
}
