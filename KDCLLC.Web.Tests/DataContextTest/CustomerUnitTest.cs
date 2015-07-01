using System;
using KDCLLC.Web.Data;
using Xunit;
using Faker;
using KDCLLC.Web.Models.Data;
using KDCLLC.Web.Data;
using System.Collections.Generic;
using Shouldly;

namespace KDCLLC.Web.Tests.DataContextTest
{
    public class CustomerUnitTest
    {
        [Fact]
        public void Customer_Add_Delete_Test()
        {
            using (DataContext db = new DataContext())
            {
                //Arrange
                Customer customer = new Customer
                {
                    Id = 0,
                    Name = Name.FullName(),
                    Address = Address.StreetAddress(),

                    PhoneNumber = Phone.Number()
                };

                //Act - Create
                db.Customers.Add(customer);
                db.SaveChanges();

                //Assert - Create
                Assert.NotEqual(0, customer.Id);
                customer.Id.ShouldBeGreaterThan(0);

                //Act - Delete
                db.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
                var result = db.SaveChanges();

                //Asset - Create
                Assert.NotEqual(0, result);
                result.ShouldBeGreaterThan(0);
            }
        }

        
    }
}
