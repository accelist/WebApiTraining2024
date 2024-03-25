
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
            Product? data = await _db.Products.Where(Q => Q.ProductID == request.ProductId).Select(Q => Q).FirstOrDefaultAsync(cancellationToken);
            if (data == null)
            {
                return new DeleteProductResponse
                {
                    Success = false,
                    Message = "Data not found."
                };
            }
            _db.Remove(data);
            await _db.SaveChangesAsync(cancellationToken);

            return new DeleteProductResponse
            {
                Success = true,
                Message = "Delete successful."
            };
        }
    }
}
