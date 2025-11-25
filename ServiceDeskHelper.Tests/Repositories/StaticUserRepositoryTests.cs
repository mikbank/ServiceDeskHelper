using ServiceDeskHelper.Core.Services;

namespace ServiceDeskHelper.Tests.Repositories
{
    [TestClass]
    public class StaticUserRepositoryTests
    {
        [TestMethod]
        public void StaticRepository_LoadStaticUsers()
        {
            // === Given ===
            var repo = new StaticUserRepository(); //uses static user repository service to fetch users

            // === When ===
            var users = repo.GetAll().ToList();

            // === Then ===
            Assert.AreEqual(3, users.Count, "CSV should contain 3 users.");
            Assert.AreEqual("Test", users[0].FirstName,"Fist name not as expected on firs user");
            Assert.AreEqual("Testesen", users[0].LastName,"Last name not as expected on first user"); 
            Assert.IsTrue(users[0].IsActive,"First User should be Active!");

            Assert.AreEqual("Test2", users[1].FirstName,"Fist name not as expected on second user");
            Assert.AreEqual("Testor", users[1].LastName,"Last name not as expected on second user"); 
            Assert.IsFalse(users[1].IsActive,"Second User should NOT be Active!"); //Second user should be inactive
        
        }
    }
}
