using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWallet.Result
{
    public class CustomerDto
    {
        public bool Response { get; set; }
        public List<Error> Messages { get; set; }

        public CustomerDto()
        {
            Messages = new List<Error>();
        }
    }
}
