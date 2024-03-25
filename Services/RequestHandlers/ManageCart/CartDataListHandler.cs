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
            var data = await _db.Carts.Select(Q => new CartData
            {
                CartId = Q.CartId,
                Quantity = Q.Quantity,
                ProductId = Q.ProductId,
                CustomerId = Q.CustomerId,
                CustomerName = Q.Customer.Name,
                ProductName = Q.Product.Name,
                Price = Q.Product.Price,
                SubTotal = (int)Q.Quantity * Q.Product.Price
            }).AsNoTracking().ToListAsync(cancellationToken);

            var response = new CartDataListResponse
            {
                Datas = data
            };

            return response;
        }

    }
}
