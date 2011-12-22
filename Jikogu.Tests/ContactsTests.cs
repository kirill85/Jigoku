﻿using NUnit.Framework;
using Jigoku.Core.Entities;
using Jigoku.ORM.Repository;
using NHibernate;
using Jigoku.Core;
using System;

namespace Jigoku.Tests
{
    [TestFixture]
    public class ContactsTests
    {
        ContactsRepository repository;
        Person person;
        [SetUp]
        public void Init()
        {
            repository = new ContactsRepository();
            person = new Person();
            person.NickName = "testNick" + DateTime.Now.Ticks.ToString();
            person.Password = "password";
            person.PrimaryMail = "testmail@example.com";
            person.Projects = null;
            using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(person);
                    transaction.Commit();
                }
            }
        }

        [Test]
        public void AddContact()
        {
            var contact = new Contacts();
            contact.Person_Contacts = person;
            contact.Contact_Type = ContactType.ICQ;
            contact.ContactValue = "111111111";

            try
            {
                TestHelper.log("Adding contact in base");
                repository.Add(contact);
                using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
                {
                    var fromDB = session.Get<Contacts>(contact.Id);
                    Assert.IsNotNull(fromDB);
                    Assert.AreNotSame(contact, fromDB);
                    Assert.AreEqual(contact.Contact_Type, fromDB.Contact_Type);
                    Assert.AreEqual(contact.ContactValue, fromDB.ContactValue);
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
            contact.Person_Contacts = person;
            contact.Contact_Type = ContactType.JID;
            contact.ContactValue = "test1@jabber.ru";

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

                contact.ContactValue = "test2@jabber.ru";
                repository.Update(contact);

                using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
                {
                    var fromDB = session.Get<Contacts>(contact.Id);
                    Assert.IsNotNull(fromDB);
                    Assert.AreEqual(contact.ContactValue, fromDB.ContactValue);
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
            contact.Person_Contacts = person;
            contact.Contact_Type = ContactType.MAILTO;
            contact.ContactValue = "test@mail.com";

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
                    var fromDB = session.Get<Contacts>(contact.Id);
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
            contact.Person_Contacts = person;
            contact.Contact_Type = ContactType.ICQ;
            contact.ContactValue = "222222";

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

                var fromDB = repository.GetById(contact.Id);
                Assert.IsNotNull(fromDB);
                Assert.AreNotSame(contact, fromDB);
                Assert.AreEqual(contact.Contact_Type, fromDB.Contact_Type);
                Assert.AreEqual(contact.ContactValue, fromDB.ContactValue);
                TestHelper.done();
            }
            catch (Exception e)
            {
                TestHelper.error(e.Message);
            }
        }
    }
}