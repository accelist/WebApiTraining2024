using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCart
{
    public class GetCartHandler : IRequestHandler<GetCartRequest, GetCartResponse>
    {
        private readonly DBContext _db;
        public GetCartHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<GetCartResponse> Handle(GetCartRequest request, CancellationToken cancellationToken)
        {
            var data = await (from x in _db.Carts
                              join y in _db.Customers on x.CustomerID equals y.CustomerID
                              join z in _db.Products on x.ProductID equals z.ProductID
                              select new CartData
                              {
                                  CartId = x.CartID,
                                  CustomerName = y.Name,
                                  ProductName = z.Name,
                                  Quantity = x.Quantity,
                                  Price = z.Price * x.Quantity
                              }).AsNoTracking().ToListAsync(cancellationToken);

            var response = new GetCartResponse
            {
                CartDatas = data
            };

            return response;
        }
    }
}
