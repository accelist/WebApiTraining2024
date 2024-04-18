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
            var query = (from c in _db.Carts
                         join p in _db.Products on c.ProductID equals p.ProductID
                         join cs in _db.Customers on c.CustomerID equals cs.CustomerID
                         where c.CustomerID == request.CustomerID
                         select new { c, p, cs }
                        );

            if (!string.IsNullOrEmpty(request.SearchQuery))
            {
                query = query.Where(Q => Q.p.Name.Contains(request.SearchQuery));
            }

            if (request.PageIndex < 1)
            {
                request.PageIndex = 1;
            }

            if (request.ItemPerPage < 1)
            {
                request.ItemPerPage = 10;
            }

            var datas = await query.Select(Q => new CartData
            {
                CartID = Q.c.CartID,
                CustomerID = Q.c.CustomerID,
                CustomerName = Q.cs.Name,
                ProductName = Q.p.Name,
                Price = Q.p.Price,
                Quantity = Q.c.Quantity
            })
            .AsNoTracking()
            .Skip((request.PageIndex - 1) * request.ItemPerPage)
            .Take(request.ItemPerPage)
            .ToListAsync(cancellationToken);

            var totalData = await query.CountAsync(cancellationToken);

            var response = new CustomerCartResponse
            {
                CartDatas = datas,
                TotalData = totalData
            };

            return response;
        }
    }
}
