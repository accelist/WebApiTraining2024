using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestHandlers.ManageCustomer.CustomerHandler
{
    public class UpdateCustomerDataListHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        private readonly DBContext _db;
        public UpdateCustomerDataListHandler(DBContext db)
        {
            _db = db;
        }
        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Customers.FindAsync(request.CustomerID);
            if (existingData == null)
            {
                return new UpdateCustomerResponse()
                {
                    Success = false,
                    Message = "Data Not Found"
                };
            }
            existingData.Name = request.Name;
            existingData.Email = request.Email;
            _db.Customers.Update(existingData);
            await _db.SaveChangesAsync(cancellationToken);
            return new UpdateCustomerResponse()
            {
                Success = true,
                Message = "Data Updated"
            };
        }
    }
}
