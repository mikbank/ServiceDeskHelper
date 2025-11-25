using ServiceDeskHelper.Core.Models;
using ServiceDeskHelper.Core.Services;
using ServiceDeskHelper.Core.Strategies;

namespace ServiceDeskHelper.Tests.Services
{
    [TestClass]
    public class UserSearchProcessorTests
    {
        [TestMethod]
        public void Processortest()
        {
            // === Given ===
            //Creates a static list of users and uses the searc functionality decoupled
            var users = new List<User>
            {
                new User(1, "John", "Smith", "IT", "a@b.com"),
                new User(2, "Jane", "Doe", "HR", "b@b.com"),
            };

            var strategy = new SearchByFullName();
            var processor = new UserSearchProcessor(strategy);

            // === When ===
            var result = processor.Search(users, "Jane").ToList();

            // === Then ===
            Assert.AreEqual(1, result.Count,"Not the expected amount of users found, should be 1");
            Assert.AreEqual("Jane", result[0].FirstName,"Not able to find correct user");
        }
    }
}
