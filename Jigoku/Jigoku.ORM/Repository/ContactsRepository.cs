using System;
using Jigoku.Core.Entities;
using NHibernate;

namespace Jigoku.ORM.Repository
{
    public class ContactsRepository : ICrudOperations<Contacts>
    {
        public void Add(Contacts contacts)
        {
            using (ISession s1 = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = s1.BeginTransaction())
                {
                    using (ISession s2 = ConfigureRepository.SessionFactory.OpenSession())
                        if (s2.Get<Contacts>(contacts.Uid) == null)
                        {
                            s1.Save(contacts);
                            transaction.Commit();
                        }
                }
            }
        }

        public void Update(Contacts contacts)
        {
            using (ISession s1 = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = s1.BeginTransaction())
                {
                    using (ISession s2 = ConfigureRepository.SessionFactory.OpenSession())
                        if (s2.Get<Contacts>(contacts.Uid) != null)
                        {
                            s1.Update(contacts);
                            transaction.Commit();
                        }
                }
            }
        }

        public void Remove(Contacts contacts)
        {
            using (ISession s1 = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = s1.BeginTransaction())
                {
                    using (ISession s2 = ConfigureRepository.SessionFactory.OpenSession())
                        if (s2.Get<Contacts>(contacts.Uid) != null)
                        {
                            s1.Delete(contacts);
                            transaction.Commit();
                        }
                }
            }
        }

        public Contacts GetById(int id)
        {
            using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
            {
                return session.Get<Contacts>(id);
            }
        }
    }
}