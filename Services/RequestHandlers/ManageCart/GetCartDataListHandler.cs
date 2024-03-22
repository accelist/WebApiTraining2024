using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Product;
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
    public class GetCartDataListHandler: IRequestHandler<CartDataListRequest,CartDataListResponse>
    {
        private readonly DBContext _db;

        public GetCartDataListHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CartDataListResponse> Handle(CartDataListRequest request, CancellationToken cancellationToken)
        {
            var datas = await (from ca in _db.Carts
                               join cu in _db.Customers on ca.CustomerID equals cu.CustomerID
                               join pr in _db.Products on ca.ProductID equals pr.ProductID
                               select new CartData
                               {
                                   CartID = ca.CartID,
                                   Quantity = ca.Quantity,
                                   CustomerName = cu.Name,
                                   CustomerEmail = cu.Email,
                                   ProductName = pr.Name,
                                   ProductPrice = pr.Price,
                                   Subtotal = ca.Quantity * pr.Price
                               }).AsNoTracking().ToListAsync(cancellationToken);

            var response = new CartDataListResponse
            {
                CartDatas = datas
            };

            return response;
        }
    }
}
