using System.Collections.Generic;

namespace Jigoku.Core.Entities
{
    public class Person
    {
        public virtual int Id { get; private set; }
        public virtual string NickName { get; set; }
        public virtual string Password { get; set; }
        public virtual string PrimaryMail { get; set; }
        public virtual string UserPhoto { get; set; }
        public virtual IList<Contacts> Contacts { get; set; }
        public virtual ISet<Project> Project { get; set; }
        public virtual IList<PrivateMessage> PrivateMessage { get; set; }
    }
}
