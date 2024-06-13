using CustomerService;

namespace CustomerServiceTests
{
    public class Tests
    {
        private CustomerServiceMain handler;

        [SetUp]
        public void Setup()
        {
            handler = new CustomerServiceMain();
        }

        [Test]
        public void FirstName_Null()
        {
            // Arrange
            var customer = new CustomerDto
            {
                Firstname = null,
                Surname = "Doe",
                EmailAddress = "Jonh.Doe@importantcompany.com",
                DateOfBirth = DateTime.Now.AddYears(-18),
                CompanyId = 1,
            };
            // Act
            var response = handler.AddCustomer(customer);

            // Assert
            Assert.That(response, Is.False);
        }

        [Test]
        public void SurName_Null()
        {
            // Arrange
            var customer = new CustomerDto
            {
                Firstname = "John",
                Surname = "",
                EmailAddress = "Jonh.Doe@importantcompany.com",
                DateOfBirth = DateTime.Now.AddYears(-18),
                CompanyId = 1,
            };
            // Act
            var response = handler.AddCustomer(customer);

            // Assert
            Assert.That(response, Is.False);
        }

        [Test]
        public void InvalidEmailAddress()
        {
            // Arrange
            var customer = new CustomerDto
            {
                Firstname = "John",
                Surname = "Doe",
                EmailAddress = "Jonh.Doe",
                DateOfBirth = DateTime.Now.AddYears(-18),
                CompanyId = 1,
            };
            // Act
            var response = handler.AddCustomer(customer);

            // Assert
            Assert.That(response, Is.False);
        }

        [Test]
        public void Under21()
        {
            // Arrange
            var customer = new CustomerDto
            {
                Firstname = "John",
                Surname = "Doe",
                EmailAddress = "Jonh.Doe",
                DateOfBirth = DateTime.Now.AddYears(-18),
                CompanyId = 1,
            };
            // Act
            var response = handler.AddCustomer(customer);

            // Assert
            Assert.That(response, Is.False);
        }

        [Test]
        public void EverythingOk()
        {
            // Arrange
            var customer = new CustomerDto
            {
                Firstname = "John",
                Surname = "Doe",
                EmailAddress = "Jonh.Doe@gmail.com",
                DateOfBirth = DateTime.Now.AddYears(-21).AddDays(-1),
                CompanyId = 1,
            };
            // Act
            var response = handler.AddCustomer(customer);

            // Assert
            Assert.That(response, Is.True);
        }
    }
}