using Contracts.ResponseModels.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RequestModels.Customer
{
    public class UpdateCustomerRequest : UpdateCustomerModel, IRequest<UpdateCustomerResponse>
    {
        public Guid? CustomerID { get; set; }
        
    }
    public class UpdateCustomerModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
