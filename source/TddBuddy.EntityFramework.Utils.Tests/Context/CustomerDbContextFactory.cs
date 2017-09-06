using System.Data.Entity.Infrastructure;
using TddBuddy.EntityFramework.Utils.DateTimeProvider;

namespace EntityFramework.Utils.Tests.Context
{
    public class CustomerDbContextFactory : IDbContextFactory<CustomerDbContext>
    {
        public CustomerDbContext Create()
        {
            return new CustomerDbContext(new DateTimeProvider());
        }
    }
}
