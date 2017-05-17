using System.Data.Entity;

namespace TddBuddy.EntityFramework.Utils
{
    public class CommonDbConfiguration : DbConfiguration
    {
        public CommonDbConfiguration()
        {
            AddInterceptor(new CreatedAndModifiedDateInterceptor());
        }
    }
}