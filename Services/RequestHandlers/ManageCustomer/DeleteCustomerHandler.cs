using Contracts.RequestModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, bool>
    {
        private readonly DBContext _db;

        public DeleteCustomerHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
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

            _db.Customers.Remove(data);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
