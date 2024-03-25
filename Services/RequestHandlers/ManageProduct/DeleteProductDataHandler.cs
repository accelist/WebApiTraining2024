using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageProduct
{
    public class DeleteProductDataHandler : IRequestHandler<DeleteProductDataRequest, DeleteProductDataResponse>
    {
        private readonly DBContext _db;
        public DeleteProductDataHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DeleteProductDataResponse> Handle(DeleteProductDataRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Products.FindAsync(request.ProductId);
            if(existingData == null)
            {
                return new DeleteProductDataResponse()
                {
                    Success = false,
                    Message = "Data Not Found"
                };
            }
            existingData.Name = request.Name;
            existingData.Price = request.Price;
            _db.Products.Remove(existingData);
            await _db.SaveChangesAsync();
            return new DeleteProductDataResponse()
            {
                Success = true,
                Message = "Data Deleted"
            };
        }
    }
}
