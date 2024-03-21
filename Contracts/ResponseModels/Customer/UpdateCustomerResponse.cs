using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ResponseModels.Customer
{
    public class UpdateCustomerResponse
    {
        public bool IsExist { get; set; }
        public string Massage { get; set; } = string.Empty;
    }
}
