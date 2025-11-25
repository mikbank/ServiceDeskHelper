using ServiceDeskHelper.Core.Services;


namespace ServiceDeskHelper.Tests.Repositories
{
    [TestClass]
    public class DebugUserRepositoryTests
    {
        [TestMethod]
        public void CSVUserRepository_LoadsCsvUsers()
        {
            // === Given === 
            //Please note testfile should only contain two users, test testesen and Test2 Testor
            var path = "C:\\Users\\mikh\\OneDrive - NIRAS\\Dokumenter\\Akademi i IT\\Avanceret Programmering\\ServiceDesk Helper\\TestUsers.csv"; //Static path, not ideal, but will do for now
            Assert.IsTrue(File.Exists(path), "Test CSV file is missing.");//Throw error on file not found

            var repo = new CSVUserRepository(path);//uses csv user repository service to fetch users

            // === When ===
            var users = repo.GetAll().ToList();

            // === Then ===
            Assert.AreEqual(3, users.Count, "CSV should contain 3 users.");
            Assert.AreEqual("Test", users[0].FirstName,"Fist name not as expected on firs user");
            Assert.AreEqual("Testesen", users[0].LastName,"Last name not as expected on first user"); 
            Assert.IsTrue(users[0].IsActive,"User should be Active!");

            Assert.AreEqual("Test2", users[1].FirstName,"Fist name not as expected on second user");
            Assert.AreEqual("Testor", users[1].LastName,"Last name not as expected on second user"); 
            Assert.IsFalse(users[1].IsActive,"User should NOT be Active!"); //Second user should be inactive
        }
    }
}
