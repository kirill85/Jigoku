using System;
using System.Linq;

using NUnit.Framework;
using Jigoku.ORM.Repository;
using Jigoku.Core.Entities;
using Jigoku.Tests;

namespace Jikogu.Tests
{
    [TestFixture]
    public class UserTest
    {
        UserRepository repository = new UserRepository();
        [Test]
        public void AddStubUser()
        {
            TestHelper.log("Adding test user John Doe");
            try
            {
                repository.AddUser("John", "Doe", "john@doe.foo");
                Assert.IsNotNull(repository);
                TestHelper.done();
            }
            catch (Exception e)
            {
                TestHelper.error(e.Message);
            }

            TestHelper.log("Searching for John Doe");
            try
            {
                User John = repository.Users.Where(x => x.PrimaryMail == "john@doe.foo").FirstOrDefault();
                if (John == null)
                {
                    TestHelper.error("John is not in database, problems Nhibernate ?");
                }
                Assert.IsNotNull(John);
                TestHelper.done();
            }
            catch (Exception e)
            {
                TestHelper.error(e.Message);
            }
        }

        [Test]
        public void DeleteStubUser()
        {
            TestHelper.log("Deleting test user John Doe");
            try
            {
                User stubUser = new User { NickName = "John", Password = "Doe", PrimaryMail = "john@doe.foo", UserPhoto = null, ContactsList = null };
                //repository.DeleteUser("John");
                Assert.IsTrue(!repository.Users.Contains(stubUser));
                TestHelper.done();
            }
            catch (Exception e)
            {
                TestHelper.error(e.Message);
            }

            TestHelper.log("Searching for John Doe");
            try
            {
                User John = repository.Users.Where(x => x.PrimaryMail == "john@doe.foo").FirstOrDefault();
                Assert.IsNull(John);
                TestHelper.done();
            }
            catch (Exception e)
            {
                TestHelper.error(e.Message);
            }
        }
    }
}
