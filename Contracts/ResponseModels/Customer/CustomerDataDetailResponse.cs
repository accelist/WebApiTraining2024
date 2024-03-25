﻿namespace Contracts.ResponseModels.Customer
{
    public class CustomerDataDetailResponse
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
