using NUnit.Framework;
using TddBuddy.EntityFramework.Utils.DateTimeProvider;

namespace EntityFramework.Utils.Tests
{
    [TestFixture]
    public class DateTimeProviderTests
    {
        [Test]
        public void DateTimeNow_ShouldReturnDateWithOutMilliseconds()
        {
            //---------------Set up test pack-------------------
            var provider = new DateTimeProvider();
            //---------------Execute Test ----------------------
            var result = provider.DateTimeNow;
            //---------------Test Result -----------------------
            Assert.AreEqual(0, result.Millisecond);
        }
    }
}
