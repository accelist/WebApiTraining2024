using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerDataRequest, DeleteCustomerDataResponse>
    {
        private readonly DBContext _db;

        public DeleteCustomerHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DeleteCustomerDataResponse> Handle(DeleteCustomerDataRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Customers.FindAsync(request.CustomerId);
            if (existingData == null)
            {
                return new DeleteCustomerDataResponse()
                {
                    Sucess = false,
                    Message = "Data Not Found"
                };
            }
            existingData.Name = request.Name;
            existingData.Email = request.Email;
            _db.Customers.Remove(existingData);
            await _db.SaveChangesAsync(cancellationToken);
            return new DeleteCustomerDataResponse()
            {
                Sucess = true,
                Message = "Data deleted"
            };
        }
    }
}
