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
            var existingData = await _db.Customers.FindAsync(request.CustomerID);
            if (existingData == null)
            {
                return new DeleteCustomerDataResponse()
                {
                    Success = false,
                    Message = "Data not found"
                };
            }
            existingData.Name = request.Name;
            existingData.Email = request.Email;
            _db.Customers.Remove(existingData);
            await _db.SaveChangesAsync(cancellationToken);
            return new DeleteCustomerDataResponse()
            {
                Success = true,
                Message = "Data deleted."
            };

        }
    }
}
