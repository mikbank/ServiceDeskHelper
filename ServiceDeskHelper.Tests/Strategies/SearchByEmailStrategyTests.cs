using ServiceDeskHelper.Core.Models;
using ServiceDeskHelper.Core.Strategies;


namespace ServiceDeskHelper.Tests.Strategies
{
    [TestClass]
    public class SearchByEmailStrategyTests
    {
        [TestMethod]
        public void TestEmail()
        {
            // === Given ===
            var users = new List<User>
            {
                new User(1, "John", "Smith", "IT", "john.smith@company.com"),
                new User(2, "Jane", "Doe", "HR", "jane@company.com"),
            };

            var strategy = new SearchByEmail();

            // === When ===
            var result = strategy.Search(users, "smith").ToList();

            // === Then ===
            Assert.AreEqual(1, result.Count,"Did not find expected amount, expected 1");
            Assert.AreEqual("john.smith@company.com", result[0].Email,"Did not find user by Email");
        }
    }
}
