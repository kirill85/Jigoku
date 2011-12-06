using NUnit.Framework;
using Jigoku.Core.Entities;
using Jigoku.ORM.Repository;
using NHibernate;
using System;

namespace Jigoku.Tests
{
    [TestFixture]
    public class ContactsTests
    {
        ContactsRepository repository;
        [SetUp]
        public void Init()
        {
            repository = new ContactsRepository();
        }

        [Test]
        public void AddContact()
        {
            var contact = new Contacts();
            contact.type = ContactType.Icq;
            contact.value = "111111111";

            try
            {
                TestHelper.log("Adding contact in base");
                repository.Add(contact);
                using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
                {
                    var fromDB = session.Get<Contacts>(contact.Uid);
                    Assert.IsNotNull(fromDB);
                    Assert.AreNotSame(contact, fromDB);
                    Assert.AreEqual(contact.type, fromDB.type);
                    Assert.AreEqual(contact.value, fromDB.value);
                    TestHelper.done();
                }
            }
            catch (Exception e)
            {
                TestHelper.error(e.Message);
            }
        }

        [Test]
        public void UpdateContact()
        {
            var contact = new Contacts();
            contact.type = ContactType.Jid;
            contact.value = "test1@jabber.ru";

            try
            {
                TestHelper.log("Update contact");
                using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(contact);
                        transaction.Commit();
                    }
                }

                contact.value = "test2@jabber.ru";
                repository.Update(contact);

                using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
                {
                    var fromDB = session.Get<Contacts>(contact.Uid);
                    Assert.IsNotNull(fromDB);
                    Assert.AreEqual(contact.value, fromDB.value);
                    TestHelper.done();
                }
            }
            catch (Exception e)
            {
                TestHelper.error(e.Message);
            }
        }

        [Test]
        public void RemoveContact()
        {
            var contact = new Contacts();
            contact.type = ContactType.MailTo;
            contact.value = "test@mail.com";

            try
            {
                TestHelper.log("Removing contact");
                using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(contact);
                        transaction.Commit();
                    }
                }

                repository.Remove(contact);

                using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
                {
                    var fromDB = session.Get<Contacts>(contact.Uid);
                    Assert.IsNull(fromDB);
                    TestHelper.done();
                }
            }
            catch (Exception e)
            {
                TestHelper.error(e.Message);
            }
        }

        [Test]
        public void GetByIdContact()
        {
            var contact = new Contacts();
            contact.type = ContactType.Icq;
            contact.value = "222222";

            try
            {
                TestHelper.log("Search contact by Uid");
                using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(contact);
                        transaction.Commit();
                    }
                }

                var fromDB = repository.GetById(contact.Uid);
                Assert.IsNotNull(fromDB);
                Assert.AreNotSame(contact, fromDB);
                Assert.AreEqual(contact.type, fromDB.type);
                Assert.AreEqual(contact.value, fromDB.value);
                TestHelper.done();
            }
            catch (Exception e)
            {
                TestHelper.error(e.Message);
            }
        }
    }
}
