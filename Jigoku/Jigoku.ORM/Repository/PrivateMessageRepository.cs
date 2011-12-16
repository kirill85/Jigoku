using Jigoku.Core.Entities;
using NHibernate;
using System;
using NHibernate.Criterion;
using System.Collections.Generic;

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
                if (message != null)
                {
                    session.Update(message);
                    transaction.Commit();
                }
                else
                {
                    throw new EntityDoesNotExistException(
                        String.Format("Message: ID={0}, does not exists in base", message.Id));
                }
            }

        }

        public void Remove(PrivateMessage message)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                    if (message != null)
                    {
                        session.Delete(message);
                        transaction.Commit();
                    }
                    else
                    {
                        throw new EntityDoesNotExistException(
                            String.Format("Message: ID={0}, does not exists in base", message.Id));
                    }
            }
        }

        public PrivateMessage GetById(int id)
        {
            return session.Get<PrivateMessage>(id);
        }

        public IList<PrivateMessage> GetBySender(Person sender)
        {
            return session.QueryOver<PrivateMessage>()
                          .Where(x => x.PersonFrom.Id == sender.Id)
                          .List();
        }

        public IList<PrivateMessage> GetByReceiver(Person receiver)
        {
            return session.QueryOver<PrivateMessage>()
                          .Where(x => x.PersonTo.Id == receiver.Id)
                          .List();
        }

        public void Dispose()
        {
            session.Dispose();
        }
    }
}
