using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jigoku.ORM.Repository.AbstractInterface;
using Jigoku.Core.Entities;

namespace Jigoku.ORM.Repository
{
    public class ProjectRepository : IEntityRepository<Project>
    {
        #region Члены IEntityRepository<Project>

        public void Add(Project type)
        {
            throw new NotImplementedException();
        }

        public void Update(Project type)
        {
            throw new NotImplementedException();
        }

        public void Remove(Project type)
        {
            throw new NotImplementedException();
        }

        public Project GetById(int Id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Члены IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
