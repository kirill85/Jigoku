using System;

namespace Jigoku.ORM.Repository
{
    public class DuplicateValueException : ArgumentException
    {
        public string ErrorMessage
        {
            get
            {
                return "Duplicate NickName can't be created";
            }
        }
    }
}
