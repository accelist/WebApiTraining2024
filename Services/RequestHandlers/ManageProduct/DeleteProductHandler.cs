using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly DBContext _db;
        public DeleteProductHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Products.FindAsync(request.ProductId);
            if (data == null)
            {
                return new DeleteProductResponse
                {
                    IsSuccess = false,
                    Message = "Id not found"
                };
            }

            _db.Products.Remove(data);
            await _db.SaveChangesAsync();

            return new DeleteProductResponse
            {
                IsSuccess = true,
                Message = "Product successfully deleted"
            };

        }
    }
}
