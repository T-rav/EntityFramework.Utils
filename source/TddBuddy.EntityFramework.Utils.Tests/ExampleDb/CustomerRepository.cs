using System.Data.Entity;
using EntityFramework.Utils.Tests.Context;

namespace EntityFramework.Utils.Tests.ExampleDb
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Customer customer)
        {
            _dbContext.Customers.Add(customer);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
        }
    }
}