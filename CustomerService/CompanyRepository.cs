using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{
    public class CompanyRepository
    {
        private readonly List<Company> Companies = new List<Company> {
            new Company {  Id = 1, Name = "VeryImportantClient" },
            new Company { Id = 2, Name = "ImportantClient" },
            new Company { Id = 3, Name = "NotImportantClient" }
        };
        
        public CompanyRepository() { }

        public Company GetById(int id)
        {
            return Companies.FirstOrDefault(x => x.Id == id)!;            
        }
    }
}
