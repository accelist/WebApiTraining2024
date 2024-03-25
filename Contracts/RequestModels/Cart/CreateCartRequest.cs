using Contracts.ResponseModels.Cart;
using MediatR;

namespace Contracts.RequestModels.Cart
{ 
    //Cart = cart id, customer id, product id, quantity
 
    //get -> customerName, productName, price, quantity, subtotal.
 
    //edit -> hanya boleh mengubah quantity, kalo quantity 0 = hapus dari cart
    public class CreateCartRequest : IRequest<CreateCartResponse>
    {
        public int Quantity { get; set; }
        public Guid ProductID { get; set; }
        public Guid CustomerID { get; set; }
    }
}
