using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;


namespace Services.RequestHandlers.ManageCustomer
{
    public class GetCustomerByIDHandler : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
    {
        private readonly DBContext _db;

        public GetCustomerByIDHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Customers.FindAsync(request.CustomerId);

            var response = new GetCustomerResponse
            {
                CustomerID = existingData.CustomerID,
                Name = existingData.Name,
                Email = existingData.Email,
            };

            return response;
        }
    }
}
