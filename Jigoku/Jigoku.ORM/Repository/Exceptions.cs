using System;

namespace Jigoku.ORM.Repository
{
    // Exception occurs when trying to update or remove a nonexistent entity
    public class EntityDoesNotExistException : Exception
    {
        public EntityDoesNotExistException(string error) : base(error)
        {
            
        }
    }
}
