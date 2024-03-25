using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Customer;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;


namespace Services.RequestHandlers.ManageProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductDataRequest, DeleteProductDataResponse>
    {
        private readonly DBContext _db;

        public DeleteProductHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DeleteProductDataResponse> Handle(DeleteProductDataRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Products.FindAsync(request.ProductID);
            if (existingData == null)
            {
                return new DeleteProductDataResponse()
                {
                    Success = false,
                    Message = "Data not found"
                };
            }
            existingData.Name = request.Name;
            existingData.Price = request.Price;
            _db.Products.Remove(existingData);
            await _db.SaveChangesAsync(cancellationToken);
            return new DeleteProductDataResponse()
            {
                Success = true,
                Message = "Data deleted."
            };

        }
    }
}
