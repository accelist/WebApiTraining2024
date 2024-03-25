using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class UpdateProductRequest : UpdateProductModel, IRequest<UpdateProductResponse>
    {
        public Guid? Id { get; set; }
    }

    public class UpdateProductModel
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
