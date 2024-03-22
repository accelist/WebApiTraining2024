
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
            //var cartData = await _db.Carts.Select(Q=> new CartDataModel
            //{
            //    CartId = Q.CartID,
            //    Quantity = Q.Quantity,
            //    ProductId = Q.ProductID,
            //    CustomerId = Q.CustomerID,
            //}).AsNoTracking().ToListAsync(cancellationToken);
            var cartData = await (from c in _db.Carts
                                  join p in _db.Products on c.ProductID equals p.ProductID
                                  join cus in _db.Customers on c.CustomerID equals cus.CustomerID
                                  select new CartDataModel
                                  {
                                    CartId = c.CartID,
                                    Quantity = c.Quantity,
                                    ProductId = c.ProductID,
                                    ProductName = p.Name,
                                    CustomerId = c.CustomerID,
                                    CustomerName = cus.Name,
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
