using System.Data.Entity.Migrations;
using EntityFramework.Utils.Tests.Context;
using EntityFramework.Utils.Tests.ExampleDb;

namespace EntityFramework.Utils.Tests.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CustomerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
