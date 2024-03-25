using Contracts.ResponseModels.Customer;
using Contracts.ResponseModels.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Product
{
    public class UpdateProductRequest : UpdateProductModel, IRequest<UpdateProductResponse>
    {
        public Guid? ProductID { get; set; }
    }
    public class UpdateProductModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
