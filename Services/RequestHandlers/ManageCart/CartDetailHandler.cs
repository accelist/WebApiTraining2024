
using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCart
{
    public class CartDetailHandler : IRequestHandler<CartDetailRequest, CartDetailResponse>
    {
        private readonly DBContext _db;
        public CartDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CartDetailResponse> Handle(CartDetailRequest request, CancellationToken cancellationToken)
        {
            CartDetailResponse? response = await (from c in _db.Carts
                                                  join p in _db.Products on c.ProductID equals p.ProductID
                                                  join cus in _db.Customers on c.CustomerID equals cus.CustomerID
                                                  where c.CartID == request.CartId
                                                  select new CartDetailResponse
                                                  {
                                                      Quantity = c.Quantity,
                                                      CustomerName = cus.Name,
                                                      ProductName = p.Name,
                                                      Price = p.Price,
                                                      Subtotal = c.Quantity * p.Price
                                                  }).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            if (response == null)
            {
                return new CartDetailResponse();
            }
            return response;
        }
    }
}
