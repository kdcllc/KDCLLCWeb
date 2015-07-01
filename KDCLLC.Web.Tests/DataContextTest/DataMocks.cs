using System.Collections.Generic;
using System.Data.Entity;
using KDCLLC.Web.Data;
using KDCLLC.Web.Models.Data;
using KDCLLC.Web.Repositories.Base;
using Faker;
using Moq;

namespace KDCLLC.Web.Tests.DataContextTest
{
    public class DataMocks
    {
        public static List<Customer> MockCustomers(int number)
        {
            List<Customer> customers = new List<Customer>();

            for (int i = 0; i < number; i++)
            {
                var count = 0;
                count += 1;
                //create
                Customer customer = new Customer
                {
                    Id = count,
                    Name = Name.FullName(),
                    Address = Address.StreetAddress(),

                    PhoneNumber = Phone.Number()
                };

                customers.Add(customer);
            }

            return customers;
        }

        public static GenericRepository<Customer> GetCustomerRepository(int number)
        {
            var customers = DataMocks.MockCustomers(number);

            var dbSet = new Mock<DbSet<Customer>>().SetupData(customers);

            var context = new Mock<DataContext>();
            context.Setup(c => c.Set<Customer>()).Returns(dbSet.Object);

            GenericRepository<Customer> repository = new GenericRepository<Customer>(context.Object);

            return repository;
        }
    }
}
