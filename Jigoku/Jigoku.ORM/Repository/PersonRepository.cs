using Jigoku.Core.Entities;
using NHibernate;
using System.Collections;
using System.Collections.Generic;
using Jigoku.ORM.Repository.AbstractInterface;
using System;

namespace Jigoku.ORM.Repository
{
    public class PersonRepository : IEntityRepository<Person>
    {
        private ISession session = null;

        public PersonRepository()
        {
            session = ConfigureRepository.SessionFactory.OpenSession();
        }

        #region Члены IEntityRepository<Person>

        public void Add(Person type)
        {
            using (var tr = session.BeginTransaction())
            {
                session.Save(type);
                tr.Commit();
            }
        }

        public void Update(Person person)
        {
            if (person != null)
            {
                using (var tr = session.BeginTransaction())
                {
                    session.SaveOrUpdate(person);
                    tr.Commit();
                }
            }
            else
            {
                throw new EntityDoesNotExistException(String.Format("User: ID={0}, does not exists in base", person.Id));
            }
        }

        public void Remove(Person person)
        {
            if (person != null)
            {
                using (var tr = session.BeginTransaction())
                {
                    session.Delete(person);
                    tr.Commit();
                }
            }
            else
            {
                throw new EntityDoesNotExistException(String.Format("User: ID={0}, does not exists in base", person.Id));
            }
        }

        public Person GetById(int Id)
        {
            return session.Get<Person>(Id);
        }

        public IList<Project> ProjectsByPerson(Person person)
        {
            var query = session.QueryOver<Project>().Where(m => m.ProjectId == person.Projects.GetEnumerator().Current.ProjectId).List();
            return query;
        }

        #endregion

        #region Члены IDisposable

        public void Dispose()
        {
            session.Dispose();
        }

        #endregion
    }
}
