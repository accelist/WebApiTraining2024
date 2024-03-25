using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCart
{
    public class CartDataDetailHandler :IRequestHandler<CartDataDetailRequest, CartDataDetailResponse>
    {
        private readonly DBContext _db;
        public CartDataDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CartDataDetailResponse> Handle(CartDataDetailRequest request, CancellationToken cancellationToken)
        {

            var data = await (from c in _db.Carts
                       join p in _db.Products on c.ProductId equals p.ProductId
                       join cu in _db.Customers on c.CustomerId equals cu.CustomerId
                       where c.CartId == request.CartId
                       select new CartDataDetailResponse()
                       {
                           CartId = c.CartId,
                           Quantity = c.Quantity,
                           ProductId = c.ProductId,
                           CustomerId = c.CustomerId,
                           CustomerName = cu.Name,
                           ProductName = p.Name,
                           Price = p.Price,
                           SubTotal = (int)c.Quantity * p.Price
                       }).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

            return data;
        }
    }
}
