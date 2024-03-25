using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestHandlers.ManageCart
{
    public class GetCartDataListHandler : IRequestHandler<CartDataListRequest, CartDataListResponse>
    {
        private readonly DBContext _db;

        public GetCartDataListHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CartDataListResponse> Handle(CartDataListRequest request, CancellationToken cancellationToken)
        {
            var datas = await (from cart in _db.Carts
                               join product in _db.Products on cart.ProductID equals product.ProductID
                               join customer in _db.Customers on cart.CustomerID equals customer.CustomerID
                               select new CartData
                               {
                                   CartID = cart.CartID,
                                   Quantity = cart.Quantity,
                                   ProductName = product.Name,
                                   CustomerName = customer.Name,
                                   Price = product.Price

                               }).AsNoTracking().ToListAsync(cancellationToken);

            var response = new CartDataListResponse
            {
                CartDatas = datas
            };

            return response;
        }
    }
}
