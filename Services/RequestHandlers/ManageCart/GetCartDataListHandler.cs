using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;


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
            var datas = await _db.Carts.Include(c => c.Customer).Include(c => c.Product).Select(c => new CartData
            {
                CartID = c.CartID,
                CustomerName = c.Customer.Name,
                ProductName = c.Product.Name,
                Price = c.Product.Price,
                Quantity = c.Quantity,
                SubTotal = c.Quantity * c.Product.Price
            }).AsNoTracking().ToListAsync(cancellationToken);

            var response = new CartDataListResponse
            {
                CartDatas = datas
            };

            return response;
        }

    }
}
