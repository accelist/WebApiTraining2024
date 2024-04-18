using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCustomer
{
    public class GetCustomerDetailHandler : IRequestHandler<CustomerDetailRequest, CustomerDetailResponse>
    {
        private readonly DBContext _db;

        public GetCustomerDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CustomerDetailResponse> Handle(CustomerDetailRequest request, CancellationToken cancellationToken)
        {
            var response = await _db.Customers
                .Where(Q => Q.CustomerID == request.CustomerID)
                .Select(Q => new CustomerDetailResponse
                {
                    CustomerID = Q.CustomerID,
                    Name = Q.Name,
                    Email = Q.Email,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
            {
                return new CustomerDetailResponse();
            }

            return response;
        }
    }
}
