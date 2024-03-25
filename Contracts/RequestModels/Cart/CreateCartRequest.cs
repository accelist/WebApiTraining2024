﻿using Contracts.ResponseModels.Cart;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Cart
{
    public class CreateCartRequest : IRequest<CreateCartResponse>
    {
        public Guid ProductID { get; set; }
        public Guid CustomerID { get; set; }

        public int Quantity { get; set; }
    }
}
