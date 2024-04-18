using Contracts.RequestModels.Product;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, bool>
    {
        private readonly DBContext _db;

        public DeleteProductHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Products
                .Where(Q => Q.ProductID == request.ProductID)
                .Select(Q => Q)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (data == null)
            {
                return false;
            }

            _db.Products.Remove(data);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
