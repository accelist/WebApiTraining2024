using Contracts.ResponseModels.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Customer
{
    public class UpdateCustomerDataRequest : UpdateCustomerDataModel, IRequest<UpdateCustomerDataResponse>
    {
        public Guid? CustomerID { get; set; }
    }

    public class UpdateCustomerDataModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
