using System;
using Jigoku.ORM.Repository.AbstractInterface;
using Jigoku.Core.Entities;
using NHibernate;
using System.Collections.Generic;

namespace Jigoku.ORM.Repository
{
    public class ProjectRepository : IEntityRepository<Project>
    {
        private ISession session = null;

        public ProjectRepository()
        {
            session = ConfigureRepository.SessionFactory.OpenSession();
        }
        #region Члены IEntityRepository<Project>

        public void Add(Project project)
        {
            using (var tr = session.BeginTransaction())
            {
                session.Save(project);
                tr.Commit();
            }
        }

        public void Update(Project project)
        {
            using (var tr = session.BeginTransaction())
            {
                session.SaveOrUpdate(project);
                tr.Commit();
            }
        }

        public void Remove(Project project)
        {
            using (var tr = session.BeginTransaction())
            {
                session.Delete(project);
                tr.Commit();
            }
        }

        public Project GetById(int Id)
        {
            return session.Get<Project>(Id);
        }

        public IList<Person> PersonsByProject(Project project)
        {
            var query = session.QueryOver<Person>().Where(m => m.Projects.GetEnumerator().Current.ProjectId == project.ProjectId).List();
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
