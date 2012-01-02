using Jigoku.Core.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using Jigoku.ORM.Repository.AbstractInterface;

namespace Jigoku.ORM.Repository
{
    public class ContactsRepository : IEntityRepository<Contacts>
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
                    session.SaveOrUpdate(contacts);
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

        public Contacts GetById(int Id)
        {
            return session.Get<Contacts>(Id);
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