
namespace Jigoku.ORM.Repository
{
    interface ICrudOperations<T>
    {
        void Add(T arg);
        void Update(T arg);
        void Remove(T arg);
        T GetById(int id);
    }
}