using System;
using System.Data.Common;
using System.Linq;
using EntityFramework.Utils.Tests.Context;
using EntityFramework.Utils.Tests.ExampleDb;
using NSubstitute;
using NUnit.Framework;
using TddBuddy.EntityFramework.Utils.DateTimeProvider;
using TddBuddy.SpeedySqlLocalDb;
using TddBuddy.SpeedySqlLocalDb.Attribute;
using TddBuddy.SpeedySqlLocalDb.Construction;

namespace EntityFramework.Utils.Tests
{
    [TestFixture, SharedSpeedyLocalDb(typeof(CustomerDbContext), typeof(DateTimeProvider))]
    public class CreatedAndModifiedInterceptorTests
    {

        [Test]
        public void WhenCreating_ShouldUpdateCreateAndModifedTimesteamp()
        {
            //---------------Set up test pack-------------------
            var createdDateTime = new DateTime(2017,1,9,10,10,9);
            var entry = CreateCustomer();
            
            using (var wrapper = CreateWrapper())
            {
                var repositoryDbContext = CreateDbContext(wrapper.Connection, createdDateTime);
                var assertDbContext = CreateDbContext(wrapper.Connection, createdDateTime);
                var customerRepository = CreateRepository(repositoryDbContext);
                //---------------Execute Test ----------------------
                customerRepository.Create(entry);
                customerRepository.Save();
                //---------------Test Result -----------------------
                var customer = assertDbContext.Customers.FirstOrDefault();
                Assert.AreEqual(createdDateTime, customer.Created);
                Assert.AreEqual(createdDateTime, customer.Modified);
            }
        }

        [Test]
        public void WhenModifying_ShouldUpdateOnlyModifedTimesteamp()
        {
            //---------------Set up test pack-------------------
            var createdDateTime = new DateTime(2017, 1, 9, 10, 10, 9);
            var modifedDateTime = new DateTime(2017, 1, 10, 11, 11, 10);
            var entry = CreateCustomer();

            using (var wrapper = CreateWrapper())
            {
                var createDbContext = CreateDbContext(wrapper.Connection, createdDateTime);
                var modifiedDbContext = CreateDbContext(wrapper.Connection, modifedDateTime);
                var assertDbContext = CreateDbContext(wrapper.Connection, createdDateTime);
                var createRepository = CreateRepository(createDbContext);
                var modifyRepository = CreateRepository(modifiedDbContext);
                //---------------Execute Test ----------------------
                createRepository.Create(entry);
                createRepository.Save();
                modifyRepository.Update(entry);
                modifyRepository.Save();
                //---------------Test Result -----------------------
                var customer = assertDbContext.Customers.FirstOrDefault();
                Assert.AreEqual(createdDateTime, customer.Created);
                Assert.AreEqual(modifedDateTime, customer.Modified);
            }
        }

        private Customer CreateCustomer()
        {
            var entry = new Customer
            {
                Id = Guid.NewGuid(),
                Company = "XYZ cash money",
                Name = "Bob the builder",
                PhoneNumber = "0892334567"
            };
            return entry;
        }

        private ICustomerRepository CreateRepository(CustomerDbContext repositoryDbContext)
        {
            return new CustomerRepository(repositoryDbContext);
        }

        private CustomerDbContext CreateDbContext(DbConnection connection,DateTime currentDateTime)
        {
            var dateTimeProvider = Substitute.For<IDateTimeProvider>();
            dateTimeProvider.DateTimeNow.Returns(currentDateTime);
            return new CustomerDbContext(connection,dateTimeProvider);
        }

        private ISpeedySqlLocalDbWrapper CreateWrapper()
        {
            return new SpeedySqlBuilder()
                .WithTransactionTimeout(2)
                .BuildWrapper();
        }
    }
}
