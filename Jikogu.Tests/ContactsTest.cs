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
        User user;
        [SetUp]
        public void Init()
        {
            repository = new ContactsRepository();
            user = new User();
            user.NickName = "testNick" + DateTime.Now.Ticks.ToString();
            user.Password = "password";
            user.PrimaryMail = "testmail@example.com";
            using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(user);
                    transaction.Commit();
                }
            }
        }

        [Test]
        public void AddContact()
        {
            var contact = new Contacts();
            contact.Owner = user;
            contact.Contact_Type = ContactType.Icq;
            contact.Value = "111111111";

            try
            {
                TestHelper.log("Adding contact in base");
                repository.Add(contact);
                using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
                {
                    var fromDB = session.Get<Contacts>(contact.Uid);
                    Assert.IsNotNull(fromDB);
                    Assert.AreNotSame(contact, fromDB);
                    Assert.AreEqual(contact.Contact_Type, fromDB.Contact_Type);
                    Assert.AreEqual(contact.Value, fromDB.Value);
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
            contact.Owner = user;
            contact.Contact_Type = ContactType.Jid;
            contact.Value = "test1@jabber.ru";

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

                contact.Value = "test2@jabber.ru";
                repository.Update(contact);

                using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
                {
                    var fromDB = session.Get<Contacts>(contact.Uid);
                    Assert.IsNotNull(fromDB);
                    Assert.AreEqual(contact.Value, fromDB.Value);
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
            contact.Owner = user;
            contact.Contact_Type = ContactType.MailTo;
            contact.Value = "test@mail.com";

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
            contact.Owner = user;
            contact.Contact_Type = ContactType.Icq;
            contact.Value = "222222";

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
                Assert.AreEqual(contact.Contact_Type, fromDB.Contact_Type);
                Assert.AreEqual(contact.Value, fromDB.Value);
                TestHelper.done();
            }
            catch (Exception e)
            {
                TestHelper.error(e.Message);
            }
        }
    }
}
