using NUnit.Framework;
using Jigoku.ORM.Repository;
using Jigoku.Core.Entities;

namespace Jikogu.Tests
{
    [TestFixture]
    public class UserTest
    {
        UserRepository repository = new UserRepository();
        [Test]
        public void AddStubUser()
        {
            repository.AddUser("John", "Doe", "john@doe.foo");
            Assert.IsNotNull(repository);
        }

        [Test]
        public void DeleteStubUser()
        {
            User stubUser = new User { NickName = "John", Password = "Doe", PrimaryMail = "john@doe.foo" };
            repository.DeleteUser("John");
            Assert.IsTrue(!repository.Users.Contains(stubUser));
        }
    }
}
