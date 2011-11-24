using System.Collections.Generic;

namespace Jigoku.Core.Entities
{
    public class User : AbstractEntity
    {
        public virtual string NickName { get; set; }
        public virtual string Password { get; set; }
        public virtual string PrimaryMail { get; set; }
        public virtual string UserPhoto { get; set; }
        public IList<Contacts> Contacts { get; set; }
    }
}
