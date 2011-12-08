using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jigoku.Core.Entities
{
    public enum ContactType
    {
        Icq = 1,
        Jid = 2,
        Msn = 3,
        MailTo = 4
    }

    public class Contacts : AbstractEntity
    {
        public virtual User Owner { get; set; }
        public virtual ContactType Contact_Type { get; set; }
        public virtual string Value { get; set; }
    }
}
