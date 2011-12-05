﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jigoku.Core.Entities
{
    public class Contacts
    {
        public virtual int Id { get; set; }
        public User User { get; set; }
        public virtual string Icq { get; set; }
        public virtual string Jid { get; set; }
        public virtual string Msn { get; set; }
        public virtual string MailTo { get; set; }
    }
}
