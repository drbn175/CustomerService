using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{
    public class CustomerDto
    {
        public string? Firstname { get; set; }

        public string? Surname { get; set; }

        public string? EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int CompanyId { get; set; }

    }
}
