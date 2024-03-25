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
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        private readonly DBContext _db;
        public DeleteCustomerHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Customers.Where(Q => Q.CustomerID == request.CustomerID)
                .AsNoTracking().FirstOrDefaultAsync();

            if (data == null)
            {
                return new DeleteCustomerResponse
                {
                    Message = "Data Not Found"
                };
            }
            _db.Customers.Remove(data);
            await _db.SaveChangesAsync(cancellationToken);
            var response = new DeleteCustomerResponse
            {
                Message = "Data Deleted"
            };
            return response;
        }
    }
}
