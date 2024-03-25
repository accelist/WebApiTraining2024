using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Customer;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;


namespace Services.RequestHandlers.ManageProduct
{
    public class ProductDetailHandler : IRequestHandler<DetailProductRequest, DetailProductResponse>
    {
        private readonly DBContext _db;

        public ProductDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DetailProductResponse> Handle(DetailProductRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Products.FindAsync(request.ProductID);

            var response = new DetailProductResponse()
            {
                ProductID = data.ProductID,
                Price = data.Price,
                Name = data.Name
            };
            return response;
        }
    }
}
