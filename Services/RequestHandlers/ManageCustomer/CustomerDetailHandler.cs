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
    public class CustomerDetailHandler: IRequestHandler<CustomerDetailRequest,CustomerDetailResponse>
    {
        private readonly DBContext _db;

        public CustomerDetailHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CustomerDetailResponse> Handle(CustomerDetailRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Customers.Where(Q => Q.CustomerID == request.CustomerID)
                .Select(Q => new CustomerData
                {
                    CustomerID = Q.CustomerID,
                    Name = Q.Name,
                    Email = Q.Email
                }).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            var result = new CustomerDetailResponse
            {
                CustomerDetails = data
            };
            return result;
        }
    }
}
