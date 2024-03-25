﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ResponseModels.Product
{
    public class UpdateProductDataResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
