using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ResponseModels.Product
{
    public class ProductDataListResponse
    {
        public List<ProductData> ProductDatas { get; set; } = new List<ProductData>();
    }

    public class ProductData
    {
        public Guid ProductID { get; set; }

        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
