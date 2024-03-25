using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCustomer
{
    public class DeleteCustomerDataHandler : IRequestHandler<DeleteCustomerDataRequest, DeleteCustomerDataResponse>
    {
        private readonly DBContext _db;
        public DeleteCustomerDataHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DeleteCustomerDataResponse> Handle(DeleteCustomerDataRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Customers.Where(Q => Q.CustomerID == request.CustomerId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            _db.Customers.Remove(existingData);
            await _db.SaveChangesAsync(cancellationToken);
            return new DeleteCustomerDataResponse();
        }
    }
}
