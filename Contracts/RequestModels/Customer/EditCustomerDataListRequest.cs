﻿using Contracts.ResponseModels.Customer;
using MediatR;

namespace Contracts.RequestModels.Customer
{
    public class EditCustomerDataListRequest : UpdateCustomerDataModel, IRequest<EditCustomerDataListResponse>
    {
        public Guid? Id { get; set; }
    }

    public class UpdateCustomerDataModel
    {
        public string Name { get; set;} = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
