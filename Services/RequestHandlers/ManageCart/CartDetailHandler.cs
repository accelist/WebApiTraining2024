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
    public class CartDetailHandler : IRequestHandler<CartDetailRequest, CartDetailResponse>
    {
        public readonly DBContext _db;
        public CartDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CartDetailResponse> Handle(CartDetailRequest request, CancellationToken cancellationToken)
        {
            var data = await (from ca in _db.Carts
                               join cu in _db.Customers on ca.CustomerID equals cu.CustomerID
                               join pr in _db.Products on ca.ProductID equals pr.ProductID
                               where ca.CartID == request.CartID
                               select new CartData
                               {
                                   CartID = ca.CartID,
                                   Quantity = ca.Quantity,
                                   CustomerName = cu.Name,
                                   CustomerEmail = cu.Email,
                                   ProductName = pr.Name,
                                   ProductPrice = pr.Price,
                                   Subtotal = ca.Quantity * pr.Price
                               }).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

            if (data == null)
            {
                return new CartDetailResponse();
            }
            var result = new CartDetailResponse
            {
                CartDetails = data
            };
            return result;
        }
    }
}
