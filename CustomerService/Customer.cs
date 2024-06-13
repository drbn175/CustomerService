using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{
    public class Customer
    {
        public string? Firstname { get; set; }

        public string? Surname { get; set; }

        public string? EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Company? Company { get; set; }

        public bool HasCreditLimit { get; set; }

        public double CreditLimit { get; set; }
    }
}
