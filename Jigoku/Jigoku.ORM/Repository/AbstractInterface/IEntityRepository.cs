using System;

namespace Jigoku.ORM.Repository.AbstractInterface
{
    public interface IEntityRepository<Type> : IDisposable
    {
        void Add(Type type);
        void Update(Type type);
        void Remove(Type type);
        Type GetById(int Id);
    }
}
