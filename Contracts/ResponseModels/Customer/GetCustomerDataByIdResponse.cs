using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ResponseModels.Customer
{
    public class GetCustomerDataByIdResponse
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
    }
}
