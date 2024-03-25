using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageCustomer
{
    public class GetCustomerDataByIdHandler : IRequestHandler<GetCustomerDataByIdRequest, GetCustomerDataByIdResponse>
    {
        private readonly DBContext _db;
        public GetCustomerDataByIdHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<GetCustomerDataByIdResponse> Handle(GetCustomerDataByIdRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Customers.FindAsync(request.CustomerId);
            
            var response = new GetCustomerDataByIdResponse
            {
                CustomerName = data.Name,
                Email = data.Email
            };

            return response;
        }
    }
}
