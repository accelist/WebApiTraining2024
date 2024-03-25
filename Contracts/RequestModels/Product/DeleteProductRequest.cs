using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.ResponseModels.Product;
using MediatR;

namespace Contracts.RequestModels.Product
{
    public class DeleteProductRequest : DeleteProductModel, IRequest<DeleteProductResponse>
    {
        public Guid Id { get; set; }
    }

    public class DeleteProductModel
    {

    }
}
