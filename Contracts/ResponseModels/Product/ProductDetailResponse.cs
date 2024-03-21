using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ResponseModels.Product
{
    public class ProductDetailResponse
    {
        public ProductData ProductDetails { get; set; } = new ProductData();
    }
}
