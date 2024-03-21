using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestHandlers.ManageCustomer
{
    internal class UpdateCustomerHandler: IRequestHandler<UpdateCustomerRequest,UpdateCustomerResponse>
    {
        private readonly DBContext _db;

        public UpdateCustomerHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Customers.Where(Q => Q.CustomerID == request.CustomerID)
                .Select(Q => Q).FirstOrDefaultAsync();
            if (existingData == null)
            {
                return new UpdateCustomerResponse
                {
                    IsExist = false,
                    Massage = "Customer ID not be found!"
                };
            }

            existingData.Name = request.Name;
            existingData.Email = request.Email;
            await _db.SaveChangesAsync(cancellationToken);

            var response = new UpdateCustomerResponse
            {
                IsExist = true,
                Massage = "Successfully updated data!"
            };

            return response;
        }
    }
}
