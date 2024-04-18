using Contracts.RequestModels.Product;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageProduct
{
    public class EditProductHandler : IRequestHandler<EditProductRequest, bool>
    {
        private readonly DBContext _db;

        public EditProductHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(EditProductRequest request, CancellationToken cancellationToken)
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

            data.Name = request.Name;
            data.Price = request.Price;
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
