using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageCustomer
{
    public class DeleteCustomerDataHandler : IRequestHandler<DeleteCustomerDataRequest, DeleteCustomerDataResponse>
    {
        public DBContext _db;
        public DeleteCustomerDataHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<DeleteCustomerDataResponse> Handle(DeleteCustomerDataRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Customers.FindAsync(request.CustomerId);
            if (data == null)
            {
                return new DeleteCustomerDataResponse
                    {
                        IsSuccess = false,
                        Message = "Data Not Found"
                    };
            }
            _db.Customers.Remove(data);
            await _db.SaveChangesAsync();

            return new DeleteCustomerDataResponse
            {
                IsSuccess = true,
                Message = "Data deleted successfully"
            };
        }
    }
}
