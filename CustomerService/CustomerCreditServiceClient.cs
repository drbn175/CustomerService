using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{
    public class CustomerCreditServiceClient: IDisposable
    {
        public CustomerCreditServiceClient() { }

        public double GetCreditLimit()
        {
            return 12.55;
        }

        public void Dispose()
        {
            // do nothing            
        }

    }
}
