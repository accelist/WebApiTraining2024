using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageProduct
{
    public class UpdateProductDataHandler : IRequestHandler<UpdateProductDataRequest, UpdateProductDataResponse>
    {
        private readonly DBContext _db;
        public UpdateProductDataHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<UpdateProductDataResponse> Handle(UpdateProductDataRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Products.FindAsync(request.Id);
            if (data == null)
            {
                return new UpdateProductDataResponse
                {
                    IsSuccess = false,
                    Message = "Update failed"
                };
            }
            data.Name = request.ProductName;
            data.Price = request.ProductPrice;

            _db.Products.Update(data);
            await _db.SaveChangesAsync();

            return new UpdateProductDataResponse
            {
                IsSuccess = true,
                Message = "Data Found"
            };
        }
    }
}
