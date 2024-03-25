using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCart
{
    public class GetCartDataListHandler : IRequestHandler<GetCartDataListRequest, GetCartDataListResponse>
    {
        private readonly DBContext _db;

        public GetCartDataListHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<GetCartDataListResponse> Handle(GetCartDataListRequest request, CancellationToken cancellationToken)
        {
            var datas = await (from cart in _db.Carts
                               join product in _db.Products on cart.ProductID equals product.ProductID
                               join customer in _db.Customers on cart.CustomerID equals customer.CustomerID
                               select new CartData
                               {
                                   CartId = cart.CartID,
                                   CustomerName = customer.Name,
                                   ProductName = product.Name,
                                   Quantity = cart.Quantity,
                                   Price = product.Price,
                                   SubTotal = cart.Quantity * product.Price
                               })
            .AsNoTracking()
            .ToListAsync(cancellationToken);

            var response = new GetCartDataListResponse
            {
                Cartdatas = datas
            };

            return response;
        }
    }
}
