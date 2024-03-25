using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCart
{
    public class GetCartByIdHandler : IRequestHandler<GetCartByIdRequest, GetCartByIdResponse>
    {
        private readonly DBContext _db;

        public GetCartByIdHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<GetCartByIdResponse> Handle(GetCartByIdRequest request, CancellationToken cancellationToken)
        {
            var cartData = await (from cart in _db.Carts
                                  join product in _db.Products on cart.ProductID equals product.ProductID
                                  join customer in _db.Customers on cart.CustomerID equals customer.CustomerID
                                  where cart.CartID == request.CartId
                                  select new
                                  {
                                      Cart = cart,
                                      Product = product,
                                      Customer = customer
                                  }).FirstOrDefaultAsync();


            var response = new GetCartByIdResponse
            {
                CartId = cartData.Cart.CartID,
                CustomerName = cartData.Customer.Name,
                ProductName = cartData.Product.Name,
                Price = cartData.Product.Price,
                Quantity = cartData.Cart.Quantity,
                SubTotal = cartData.Cart.Quantity * cartData.Product.Price,
            };

            return response;
        }
    }
}
