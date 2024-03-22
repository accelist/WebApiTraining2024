using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ResponseModels.Cart
{
    public class CartDetailResponse
    {
        public CartData CartDetails { get; set; } = new CartData();
    }
}
