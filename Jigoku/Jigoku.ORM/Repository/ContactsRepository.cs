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
<<<<<<< HEAD
                    session.Save(contacts);
                    transaction.Commit();
=======
                    using (ISession s2 = ConfigureRepository.SessionFactory.OpenSession())
                        if (s2.Get<Contacts>(contacts.Uid) == null)
                        {
                            s1.Save(contacts);
                            transaction.Commit();
                        }
>>>>>>> 788686b3eeaa9cde891be557deff6020a2976a00
                }
            }
        }

        public void Update(Contacts contacts)
        {
            using (ISession s1 = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = s1.BeginTransaction())
                {
<<<<<<< HEAD
                    session.Update(contacts);
                    transaction.Commit();
=======
                    using (ISession s2 = ConfigureRepository.SessionFactory.OpenSession())
                        if (s2.Get<Contacts>(contacts.Uid) != null)
                        {
                            s1.Update(contacts);
                            transaction.Commit();
                        }
>>>>>>> 788686b3eeaa9cde891be557deff6020a2976a00
                }
            }
        }

        public void Remove(Contacts contacts)
        {
            using (ISession s1 = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = s1.BeginTransaction())
                {
<<<<<<< HEAD
                    session.Delete(contacts);
                    transaction.Commit();
=======
                    using (ISession s2 = ConfigureRepository.SessionFactory.OpenSession())
                        if (s2.Get<Contacts>(contacts.Uid) != null)
                        {
                            s1.Delete(contacts);
                            transaction.Commit();
                        }
>>>>>>> 788686b3eeaa9cde891be557deff6020a2976a00
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