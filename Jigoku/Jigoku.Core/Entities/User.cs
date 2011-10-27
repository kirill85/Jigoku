using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jigoku.Core.Entities
{
    public class User : AbstractEntity
    {
        public virtual string NickName { get; set; }
        public virtual string Password { get; set; }
        public virtual string PrimaryMail { get; set; }
        public virtual byte[] UserPhoto { get; set; }
        public IList<Contacts> ContactsList { get; set; }
    }
}
