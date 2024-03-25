using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageProduct
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly DBContext _db;
        public GetProductByIdHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Products.FindAsync(request.ProductId);
            var response = new GetProductByIdResponse
            {
                ProductName = data.Name,
                ProductPrice = data.Price,
            };

            return response;
        }
    }
}
