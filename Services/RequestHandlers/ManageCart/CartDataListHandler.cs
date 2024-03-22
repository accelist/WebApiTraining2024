
using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCart
{
    public class CartDataListHandler : IRequestHandler<CartDataListRequest, CartDataListResponse>
    {
        private readonly DBContext _db;
        public CartDataListHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CartDataListResponse> Handle(CartDataListRequest request, CancellationToken cancellationToken)
        {
            var cartData = await _db.Carts.Select(Q=> new CartDataModel
            {
                CartId = Q.CartID,
                Quantity = Q.Quantity,
                ProductId = Q.ProductID,
                CustomerId = Q.CustomerID,
            }).AsNoTracking().ToListAsync(cancellationToken);
            if(cartData == null)
            {
                return new CartDataListResponse();
            }

            return new CartDataListResponse()
            {
                Data = cartData,
            };
        }
    }
}
