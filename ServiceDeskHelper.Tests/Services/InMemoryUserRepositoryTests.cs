using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceDeskHelper.Models;
using ServiceDeskHelper.Services;

namespace ServiceDeskHelper.Tests.Services;

[TestClass]
public class InMemoryUserRepositoryTests
{
    [TestMethod]
    public void Add_IncreasesCount_And_GetByIdFindsUser()
    {
        var repo = new InMemoryUserRepository();
        var user = new User(1, "alice", "IT", "Admin");

        repo.Add(user);

        Assert.AreEqual(1, repo.GetAll().Count());
        Assert.IsNotNull(repo.GetById(1));
        Assert.AreEqual("alice", repo.GetById(1)!.Username);
    }

    [TestMethod]
    public void Delete_RemovesUser_ReturnsTrue_WhenFound()
    {
        var repo = new InMemoryUserRepository();
        repo.Add(new User(2, "bob", "Support", "Technician"));

        var removed = repo.Delete(2);

        Assert.IsTrue(removed);
        Assert.AreEqual(0, repo.GetAll().Count());
    }
}
