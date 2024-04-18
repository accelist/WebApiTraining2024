using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCart
{
    public class CustomerCartHandler : IRequestHandler<CustomerCartRequest, CustomerCartResponse>
    {
        private readonly DBContext _db;

        public CustomerCartHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CustomerCartResponse> Handle(CustomerCartRequest request, CancellationToken cancellationToken)
        {
            var datas = await (from c in _db.Carts
                               join p in _db.Products on c.ProductID equals p.ProductID
                               join cs in _db.Customers on c.CustomerID equals cs.CustomerID
                               where c.CustomerID == request.CustomerID
                               select new CartData
                               {
                                   CartID = c.CartID,
                                   CustomerID = c.CustomerID,
                                   CustomerName = cs.Name,
                                   ProductName = p.Name,
                                   Price = p.Price,
                                   Quantity = c.Quantity
                               })
                                .AsNoTracking()
                                .ToListAsync(cancellationToken);

            var response = new CustomerCartResponse
            {
                CartDatas = datas
            };

            return response;
        }
    }
}
