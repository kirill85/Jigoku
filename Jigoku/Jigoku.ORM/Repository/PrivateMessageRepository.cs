using Jigoku.Core.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using Jigoku.ORM.Repository.AbstractInterface;

namespace Jigoku.ORM.Repository
{
    public class PrivateMessageRepository : IEntityRepository<PrivateMessage>
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
                    session.SaveOrUpdate(message);
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

        public IList<PrivateMessage> GetByText(string text)
        {
            int lenMatchPattern = text.Length;
            var query = session.QueryOver<PrivateMessage>().Where(m => m.Body.Substring(0, lenMatchPattern) == text).List();
            return query;
        }

        public IList<PrivateMessage> GetByUser(string userText)
        {
            int lenUserPattern = userText.Length;
            var query = session.QueryOver<PrivateMessage>().Where(m => m.PersonFrom.NickName.Substring(0, lenUserPattern) == userText).List();
            return query;
        }

        public void Dispose()
        {
            session.Dispose();
        }
    }
}
