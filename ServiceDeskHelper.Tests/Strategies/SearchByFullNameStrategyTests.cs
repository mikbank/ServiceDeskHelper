using ServiceDeskHelper.Core.Models;
using ServiceDeskHelper.Core.Strategies;

namespace ServiceDeskHelper.Tests.Strategies
{
    [TestClass]
    public class SearchByFullNameStrategyTests
    {
        [TestMethod]
        public void TestFullName()
        {
            // === Given ===
            var users = new List<User>
            {
                new User(1, "John", "Smith", "IT", "john@x.com"),
                new User(2, "Jane", "Doe", "HR", "jane@x.com"),
                new User(3, "Samantha", "Johnsen", "Finance", "sam@x.com")
            };

            var strategy = new SearchByFullName();

            // === When ===
            var result = strategy.Search(users, "John").ToList();

            // === Then ===
            Assert.AreEqual(2, result.Count,"Did not find right amount of users");
            Assert.IsTrue(result.Any(u => u.FirstName == "John"),"Did not find user on First name");
            Assert.IsTrue(result.Any(u => u.LastName == "Johnsen"),"Did not find expected user on last name");
        }
    }
}