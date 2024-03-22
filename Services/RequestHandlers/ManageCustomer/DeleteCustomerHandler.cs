
using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCustomer
{

    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        public readonly DBContext _db;
        public DeleteCustomerHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Customers.Where(Q => Q.CustomerID == request.CustomerID).Select(Q => Q).FirstOrDefaultAsync(cancellationToken);

            if (data == null)
            {
                return new DeleteCustomerResponse
                {
                    Success = false,
                    Message = "Data not found.",
                };
            }
            _db.Customers.Remove(data);
            await _db.SaveChangesAsync(cancellationToken);

            return new DeleteCustomerResponse
            {
                Success = true,
                Message = "Delete success.",
            };
        }
    }
}
