using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;


namespace Services.RequestHandlers.ManageCustomer
{
    public class CustomerDetailHandler : IRequestHandler<CreateCustomerDetailRequest, CreateCustomerDetailResponse>
    {
        private readonly DBContext _db;

        public CustomerDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CreateCustomerDetailResponse> Handle(CreateCustomerDetailRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Customers.FindAsync(request.CustomerID);

            var response = new CreateCustomerDetailResponse()
            {
                CustomerID = data.CustomerID,
                Email = data.Email,
                Name = data.Name
            };
            return response;
        }
    }
}
