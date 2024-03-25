﻿using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Cart
{
    public class CartDataListRequest : IRequest<CartDataListResponse>
    {
    }
}