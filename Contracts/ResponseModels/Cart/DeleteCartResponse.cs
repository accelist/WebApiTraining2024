﻿namespace Contracts.ResponseModels.Cart
{
    public class DeleteCartResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
