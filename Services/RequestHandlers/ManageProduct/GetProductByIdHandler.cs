using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Customer;
using Contracts.ResponseModels.Product;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageProduct
{
    internal class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly DBContext _db;

        public GetProductByIdHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Products.FindAsync(request.ProductId);

            var response = new GetProductByIdResponse
            {
                Id = existingData.ProductID,
                ProductName = existingData.Name,
                Price = existingData.Price,
            };

            return response;
        }
    }
}
