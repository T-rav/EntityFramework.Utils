using System;
using System.Data.Common;
using System.Data.Entity;
using EntityFramework.Utils.Tests.ExampleDb;
using TddBuddy.EntityFramework.Utils;
using TddBuddy.EntityFramework.Utils.DateTimeProvider;

namespace EntityFramework.Utils.Tests.Context
{
    [DbConfigurationType(typeof(CommonDbConfiguration))]
    public class CustomerDbContext : DbContext, IDateTimeProvider
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public DateTime DateTimeNow => _dateTimeProvider.DateTimeNow;

        public CustomerDbContext(IDateTimeProvider dateTimeProvider) : base("ExampleDb")
        {
            _dateTimeProvider = dateTimeProvider;
            Database.SetInitializer<CustomerDbContext>(null);
        }

        public CustomerDbContext(DbConnection connection, IDateTimeProvider dateTimeProvider) : base(connection, false)
        {
            _dateTimeProvider = dateTimeProvider;
            Database.SetInitializer<CustomerDbContext>(null);
        }

        public IDbSet<Customer> Customers { get; set; }
    }
}
