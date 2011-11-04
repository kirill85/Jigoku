using NUnit.Framework;
using Jigoku.ORM;
using Jigoku.ORM.Repository;
namespace Jikogu.Tests
{
    [TestFixture]
    public class AddUserTest
    {
        [Test]
        public void AddStubUser()
        {
            UserRepository repository = new UserRepository();
            repository.AddUser("John", "Doe", "john@doe.foo");
            Assert.IsNotNull(repository);
        }
    }
}
