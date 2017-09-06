namespace EntityFramework.Utils.Tests.ExampleDb
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        void Save();
        void Update(Customer customer);
    }
}