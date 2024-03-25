using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageCustomer
{
    public class UpdateCustomerDataHandler : IRequestHandler<EditCustomerDataListRequest, EditCustomerDataListResponse>
    {
        private readonly DBContext _db;
        public UpdateCustomerDataHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<EditCustomerDataListResponse> Handle(EditCustomerDataListRequest request, CancellationToken ct)
        {
            var existingData = await _db.Customers.FindAsync(request.Id);
            if (existingData == null) 
            {
                return new EditCustomerDataListResponse
                {
                    IsSuccess = false,
                    Message = "Data Not Found"
                };
            }

            existingData.Name = request.Name;
            existingData.Email = request.Email;

            _db.Customers.Update(existingData);
            await _db.SaveChangesAsync(ct);

            return new EditCustomerDataListResponse
            {
                IsSuccess = true,
                Message = "Data Updated"
            };
        }
    }
}
