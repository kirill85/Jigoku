using Jigoku.Core.Entities;
using NHibernate;

namespace Jigoku.ORM.Repository
{
    public class ContactsRepository : ICrudOperations<Contacts>
    {
        public void Add(Contacts contacts)
        {
            using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(contacts);
                    transaction.Commit();
                }
            }
        }

        public void Update(Contacts contacts)
        {
            using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    session.Update(contacts);
                    transaction.Commit();

                }
            }
        }

        public void Remove(Contacts contacts)
        {
            using (ISession session = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(contacts);
                    transaction.Commit();
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