using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceDeskHelper.Core.Models;
using ServiceDeskHelper.Core.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace ServiceDeskHelper.Tests.Strategies
{
    [TestClass]
    public class SearchByEmailStrategyTests
    {
        [TestMethod]
        public void Search_GivenUsersList_WhenSearchingByEmail_ThenOnlyMatchingEmailIsReturned()
        {
            // === Given ===
            var users = new List<User>
            {
                new User(1, "John", "Smith", "IT", "john.smith@company.com"),
                new User(2, "Jane", "Doe", "HR", "jane@company.com"),
            };

            var strategy = new SearchByEmailStrategy();

            // === When ===
            var result = strategy.Search(users, "smith").ToList();

            // === Then ===
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("john.smith@company.com", result[0].Email);
        }
    }
}
