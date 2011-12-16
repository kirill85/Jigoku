﻿using Jigoku.Core.Entities;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Jigoku.ORM.Repository
{
    public class ContactsRepository : IDisposable
    {
        ISession session;

        public ContactsRepository()
        {
            session = ConfigureRepository.SessionFactory.OpenSession();
        }

        public void Add(Contacts contacts)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(contacts);
                transaction.Commit();
            }
        }

        public void Update(Contacts contacts)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                if (contacts != null)
                {
                    session.Update(contacts);
                    transaction.Commit();
                }
                else
                {
                    throw new EntityDoesNotExistException(
                        String.Format("Contact: ID={0}, does not exists in base", contacts.Id));
                }
            }
        }

        public void Remove(Contacts contacts)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                if (contacts != null)
                {
                    session.Delete(contacts);
                    transaction.Commit();
                }
                else
                {
                    throw new EntityDoesNotExistException(
                        String.Format("Contact: ID={0}, does not exists in base", contacts.Id));
                }
            }
        }

        public Contacts GetById(int id)
        {
            return session.Get<Contacts>(id);
        }

        public IList<Contacts> GetByPerson(Person person)
        {
            return session.QueryOver<Contacts>()
                          .Where(x => x.Person_Contacts.Id == person.Id)
                          .List();
        }

        public void Dispose()
        {
            session.Dispose();
        }
    }
}