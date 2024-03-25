using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCustomer
{
    public class GetCustomerDataListHandler : IRequestHandler<CustomerDataListRequest, CustomerDataListResponse>
    {
        private readonly DBContext _db;

        public GetCustomerDataListHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CustomerDataListResponse> Handle(CustomerDataListRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Customers.Select(Q => new CustomerData
            {
                CustomerId = Q.CustomerId,
                Name = Q.Name,
                Email = Q.Email
            }).AsNoTracking().ToListAsync(cancellationToken);

            var response = new CustomerDataListResponse
            {
                CustomerData = data
            };

            return response;
        }
    }
}
