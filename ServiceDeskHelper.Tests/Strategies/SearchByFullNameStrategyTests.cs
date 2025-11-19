using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceDeskHelper.Core.Models;
using ServiceDeskHelper.Core.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace ServiceDeskHelper.Tests.Strategies
{
    [TestClass]
    public class SearchByFullNameStrategyTests
    {
        [TestMethod]
        public void Search_GivenUsersList_WhenSearchingForFullName_ThenMatchingUsersAreReturned()
        {
            // === Given ===
            var users = new List<User>
            {
                new User(1, "John", "Smith", "IT", "john@x.com"),
                new User(2, "Jane", "Doe", "HR", "jane@x.com"),
                new User(3, "Samantha", "Johnsen", "Finance", "sam@x.com")
            };

            var strategy = new SearchByFullNameStrategy();

            // === When ===
            var result = strategy.Search(users, "John").ToList();

            // === Then ===
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Any(u => u.FirstName == "John"));
            Assert.IsTrue(result.Any(u => u.LastName == "Johnsen"));
        }
    }
}