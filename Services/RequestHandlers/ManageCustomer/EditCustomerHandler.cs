using Contracts.RequestModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCustomer
{
    public class EditCustomerHandler : IRequestHandler<EditCustomerRequest, bool>
    {
        private readonly DBContext _db;

        public EditCustomerHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(EditCustomerRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Customers
                .Where(Q => Q.CustomerID == request.CustomerID)
                .Select(Q => Q)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (data == null)
            {
                return false;
            }

            data.Email = request.Email;
            data.Name = request.Name;
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
