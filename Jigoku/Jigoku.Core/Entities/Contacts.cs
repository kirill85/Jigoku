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
        /*
        public virtual string Icq { get; set; }
        public virtual string Jid { get; set; }
        public virtual string Msn { get; set; }
        public virtual string MailTo { get; set; }
         */
        public virtual ContactType type { get; set; }
        public virtual string value { get; set; }
    }
}
