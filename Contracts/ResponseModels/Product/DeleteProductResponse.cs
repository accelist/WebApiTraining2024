﻿
namespace Contracts.ResponseModels.Product
{
    public class DeleteProductResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}