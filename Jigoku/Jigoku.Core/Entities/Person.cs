using System.Collections.Generic;

namespace Jigoku.Core.Entities
{
    public class Person
    {
        public virtual int Id { get; private set; }
        public virtual string NickName { get; set; }
        public virtual string Password { get; set; }
        public virtual string PrimaryMail { get; set; }
        public virtual string UserPhoto { get; set; }//URL gravatar 
        public virtual ISet<Project> Projects { get; set; }

        public Person()
        {
            Projects = new HashSet<Project>();
        }
    }
}
