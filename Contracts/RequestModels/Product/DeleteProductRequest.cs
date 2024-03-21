using Contracts.ResponseModels.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Product
{
    public class DeleteProductRequest: IRequest<DeleteProductResponse>
    {
        public Guid? ProductID { get; set; }
    }
}
