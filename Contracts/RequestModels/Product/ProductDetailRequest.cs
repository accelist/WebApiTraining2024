using Contracts.ResponseModels.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Product
{
    public class ProductDetailRequest: IRequest<ProductDetailResponse>
    {
        public Guid? ProductID { get; set; }
    }
}
