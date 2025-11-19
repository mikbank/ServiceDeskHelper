using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceDeskHelper.Core.Models;
using ServiceDeskHelper.Core.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace ServiceDeskHelper.Tests.Strategies
{
    [TestClass]
    public class DepartmentFilterStrategyTests
    {
        [TestMethod]
        public void Filter_GivenUsersList_WhenFilteringByDepartment_ThenOnlyUsersInDepartmentAreReturned()
        {
            // === Given ===
            var users = new List<User>
            {
                new User(1, "John", "Smith", "IT", "a@b.com"),
                new User(2, "Jane", "Doe", "HR", "b@b.com"),
            };

            var strategy = new DepartmentFilterStrategy("IT");

            // === When ===
            var result = strategy.Filter(users).ToList();

            // === Then ===
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("IT", result[0].Department);
        }
    }
}
