

using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCustomer
{
    public class CustomerDetailHandler : IRequestHandler<CustomerDetailRequest, CustomerDetailResponse>
    {
        private readonly DBContext _db;
        public CustomerDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CustomerDetailResponse> Handle(CustomerDetailRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Customers.Where(Q => Q.CustomerID == request.CustomerID).Select(Q => new CustomerDetailResponse
            {
                CustomerID = Q.CustomerID,
                Email = Q.Email,
                Name = Q.Name,
            }).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            if (data == null)
            {
                return new CustomerDetailResponse();
            }
            return data;
        }
    }
}
