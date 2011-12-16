using Jigoku.Core.Entities;
using NHibernate;
using System;

namespace Jigoku.ORM.Repository
{
    public class PrivateMessageRepository : IDisposable
    {
        ISession session;

        public PrivateMessageRepository()
        {
            session = ConfigureRepository.SessionFactory.OpenSession();
        }

        public void Add(PrivateMessage message)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(message);
                transaction.Commit();
            }
        }

        public void Update(PrivateMessage message)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                using (ISession check = ConfigureRepository.SessionFactory.OpenSession())
                {
                    if (check.Get<PrivateMessage>(message.Id) != null)
                    {
                        session.Update(message);
                        transaction.Commit();
                    }
                    else
                    {
                        var exception = new EntityDoesNotExistException(
                            String.Format("Message: ID={0}, does not exists in base", message.Id));
                        throw exception;
                    }
                }
            }

        }

        public void Remove(PrivateMessage message)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                using (ISession check = ConfigureRepository.SessionFactory.OpenSession())
                {
                    if (check.Get<PrivateMessage>(message.Id) != null)
                    {
                        session.Delete(message);
                        transaction.Commit();
                    }
                    else
                    {
                        var exception = new EntityDoesNotExistException(
                            String.Format("Message: ID={0}, does not exists in base", message.Id));
                        throw exception;
                    }
                }
            }
        }

        public PrivateMessage GetById(int id)
        {
            return session.Get<PrivateMessage>(id);
        }

        public void Dispose()
        {
            session.Dispose();
        }
    }
}