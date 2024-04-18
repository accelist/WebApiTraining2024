using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using Entity.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.RequestHandlers.ManageCustomer
{
    public class GetCustomerDataListHandler : IRequestHandler<CustomerDataListRequest, CustomerDataListResponse>
    {
        private readonly DBContext _db;

        public GetCustomerDataListHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<CustomerDataListResponse> Handle(CustomerDataListRequest request, CancellationToken cancellationToken)
        {
            var query = _db.Customers.AsQueryable();


            if (!string.IsNullOrEmpty(request.SearchQuery))
            {
                query = query.Where(Q => Q.Name.Contains(request.SearchQuery));
            }

            if (request.PageIndex < 1)
            {
                request.PageIndex = 1;
            }

            if (request.ItemPerPage < 1)
            {
                request.ItemPerPage = 10;
            }

            var datas = await query.Select(Q => new CustomerData
            {
                CustomerID = Q.CustomerID,
                Name = Q.Name,
                Email = Q.Email,
            })
            .AsNoTracking()
            .Skip((request.PageIndex - 1) * request.ItemPerPage)
            .Take(request.ItemPerPage)
            .ToListAsync(cancellationToken);

            var totalData = await query.CountAsync(cancellationToken);

            var response = new CustomerDataListResponse
            {
                CustomerDatas = datas,
                TotalData = totalData
            };

            return response;
        }
    }
}
