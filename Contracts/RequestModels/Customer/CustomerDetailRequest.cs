﻿using Contracts.ResponseModels.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Customer
{
    public class CustomerDetailRequest: IRequest<CustomerDetailResponse>
    {
        public Guid? CustomerID { get; set; }
    }
}
