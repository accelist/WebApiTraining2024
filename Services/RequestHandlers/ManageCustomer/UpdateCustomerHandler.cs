
using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        private readonly DBContext _db;
        public UpdateCustomerHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var selectedData = await _db.Customers.Where(Q => Q.CustomerID == request.CustomerId).Select(Q => Q).FirstOrDefaultAsync(cancellationToken);
            var response = new UpdateCustomerResponse();
            if (selectedData == null)
            {
                response.Success = false;
                response.Message = "Data not found!";
                return response;
            }
            selectedData.Name = request.Name;
            selectedData.Email = request.Email;
            await _db.SaveChangesAsync(cancellationToken);

            response.Success = true;
            response.Message = "Edit successful.";
            return response;

        }
    }
}
