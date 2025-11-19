using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceDeskHelper.Core.Models;
using ServiceDeskHelper.Core.Services;
using ServiceDeskHelper.Core.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace ServiceDeskHelper.Tests.Services
{
    [TestClass]
    public class UserSearchProcessorTests
    {
        [TestMethod]
        public void Search_GivenStrategyAndUsers_WhenSearching_ThenStrategyIsApplied()
        {
            // === Given ===
            var users = new List<User>
            {
                new User(1, "John", "Smith", "IT", "a@b.com"),
                new User(2, "Jane", "Doe", "HR", "b@b.com"),
            };

            var strategy = new SearchByFullNameStrategy();
            var processor = new UserSearchProcessor(strategy);

            // === When ===
            var result = processor.Search(users, "Jane").ToList();

            // === Then ===
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Jane", result[0].FirstName);
        }
    }
}
