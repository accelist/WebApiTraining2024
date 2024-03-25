using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var existingData = await _db.Products.Where(Q => Q.ProductID == request.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            _db.Products.Remove(existingData);
            await _db.SaveChangesAsync(cancellationToken);
            return new DeleteProductResponse()
            {
                Message = "Product Deleted"
            };
        }
    }
}
