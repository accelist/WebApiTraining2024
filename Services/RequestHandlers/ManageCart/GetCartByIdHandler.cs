using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
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
            var data = await _db.Carts.Include(C => C.Customer)
                .Include(P => P.Product)
                .FirstOrDefaultAsync(Q => Q.CartID == request.CartId);
            var response = new GetCartByIdResponse
            {
                CustomerName = data.Customer.Name,
                ProductName = data.Product.Name,
                Quantity = data.Quantity,
                Price = data.Product.Price * data.Quantity
            };

            return response;
        }
    }
}
