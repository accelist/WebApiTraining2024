using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCart
{
    public class DetailCartHandler : IRequestHandler<DetailCartRequest, DetailCartResponse>
    {
        private readonly DBContext _db;
        public DetailCartHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DetailCartResponse> Handle(DetailCartRequest request, CancellationToken cancellationToken)
        {

            var data = await (from c in _db.Carts
                              join p in _db.Products on c.ProductID equals p.ProductID
                              join cu in _db.Customers on c.CustomerID equals cu.CustomerID
                              where c.CartID == request.CartID
                              select new DetailCartResponse()
                              {
                                  CartID = c.CartID,
                                  Quantity = c.Quantity,
                                  ProductID = c.ProductID,
                                  CustomerID = c.CustomerID,
                                  CustomerName = cu.Name,
                                  ProductName = p.Name,
                                  Price = p.Price,
                                  SubTotal = (int)c.Quantity * p.Price
                              }).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

            return data;
        }
    }
}
