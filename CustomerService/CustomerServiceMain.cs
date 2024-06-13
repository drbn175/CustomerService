using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace CustomerService
{
    public class CustomerServiceMain
    {
        public bool AddCustomer(CustomerDto customerDto)
        {
            var validCustomer = ValidateCustomer(customerDto);

            if (validCustomer)
            {

                var companyRepository = new CompanyRepository();
                var company = companyRepository.GetById(customerDto.CompanyId);

                var customer = new Customer
                {
                    Company = company,
                    DateOfBirth = customerDto.DateOfBirth,
                    EmailAddress = customerDto.EmailAddress,
                    Firstname = customerDto.Firstname,
                    Surname = customerDto.Surname
                };

                customer.HasCreditLimit = true;
                switch (company.Name)
                {
                    case "VeryImportantClient":

                        customer.HasCreditLimit = false;
                        break;
                    case "ImportantClient":
                        customer.CreditLimit = CreditLimit() * 2;
                        break;
                    default:
                        customer.CreditLimit = CreditLimit();
                        break;
                }

                if (customer.HasCreditLimit && customer.CreditLimit < 500)
                {
                    validCustomer = false;
                }
                else
                {
                    CustomerDataAccess.AddCustomer(customer);
                }

            }   
            return validCustomer;
        }

        private double CreditLimit()
        {
            using (var customerCreditService = new CustomerCreditServiceClient())
            {
                return  customerCreditService.GetCreditLimit();
            }
        }

        private bool ValidateCustomer(CustomerDto customer)
        {
            var result = true;
            if (string.IsNullOrEmpty(customer.Firstname) || string.IsNullOrEmpty(customer.Surname))
            {
                result= false;
            }

            if (string.IsNullOrEmpty(customer.EmailAddress) || !IsValidEmailRegex(customer.EmailAddress))
            {
                result = false;
            }


            if (new DateTime(DateTime.Now.Subtract(customer.DateOfBirth).Ticks).Year < 21) { 
                result = false;
            }

            return result;
        }

        private static bool IsValidEmailRegex(string email)
        {
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
