using Jigoku.Core.Entities;
using NHibernate;

namespace Jigoku.ORM.Repository
{
    public class ContactsRepository
    {
        public void Add(Contacts contacts)
        {
            using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    if (session.Get<Contacts>(contacts.Uid) == null)
                    {
                        session.Save(contacts);
                        transaction.Commit();
                    }
                }
            }
        }

        public void Update(Contacts contacts)
        {
            using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    if (session.Get<Contacts>(contacts.Uid) != null)
                    {
                        session.Update(contacts);
                        transaction.Commit();
                    }
                }
            }
        }

        public void Remove(Contacts contacts)
        {
            using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    if (session.Get<Contacts>(contacts.Uid) != null)
                    {
                        session.Delete(contacts);
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