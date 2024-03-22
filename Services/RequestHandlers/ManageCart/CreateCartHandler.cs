using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Services.RequestHandlers.ManageCart
{
    /// <summary>
    /// Adds a new Cart into the database. Cart contains product and customer objects according to ID. This also adds the new cart object into the lists defined in product and customer.
    /// </summary>
    public class CreateCartHandler : IRequestHandler<CreateCartRequest, CreateCartResponse>
    {
        private readonly DBContext _db;
        public CreateCartHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CreateCartResponse> Handle(CreateCartRequest request, CancellationToken cancellationToken)
        {
            Product? product = await _db.Products.Where(Q => Q.ProductID == request.ProductID).Select(Q => Q).FirstOrDefaultAsync(cancellationToken);
            Customer? customer = await _db.Customers.Where(Q => Q.CustomerID == request.CustomerID).Select(Q => Q).FirstOrDefaultAsync(cancellationToken);

            if(product == null || customer==null)
            {
                return new CreateCartResponse();
            }

            Cart newCart = new Cart
            {
                CartID = Guid.NewGuid(),
                Quantity = request.Quantity,
                ProductID = request.ProductID,
                CustomerID = customer.CustomerID,
                Product = product,
                Customer = customer,
            };
            product.Carts.Add(newCart);
            customer.Carts.Add(newCart);
            _db.Carts.Add(newCart);
            await _db.SaveChangesAsync(cancellationToken);

            return new CreateCartResponse()
            {
                CartId = newCart.CartID,
                CustomerId = newCart.CustomerID,
                ProductId = newCart.ProductID,
                Quantity = request.Quantity,
            };
        }
    }
}
