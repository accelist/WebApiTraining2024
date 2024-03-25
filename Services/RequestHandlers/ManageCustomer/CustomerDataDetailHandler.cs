using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageCustomer
{
    public class CustomerDataDetailHandler : IRequestHandler<CustomerDataDetailRequest, CustomerDataDetailResponse>
    {
        private readonly DBContext _db;

        public CustomerDataDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CustomerDataDetailResponse> Handle(CustomerDataDetailRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Customers.FindAsync(request.CustomerId);

            var response = new CustomerDataDetailResponse()
            {
                CustomerId = data.CustomerId,
                Email = data.Email,
                Name = data.Name
            };
            return response;
        }
    }
}
