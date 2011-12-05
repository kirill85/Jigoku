using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jigoku.Core.Entities
{
    public class PrivateMessage
    {
        public virtual int Id { get; private set; }
        public virtual IList<User> IdTo { get; set; }
        public virtual IList<User> IdFrom { get; set; }
        public virtual string Topic { get; set; }
        public virtual string Body { get; set; }
        public virtual byte[] Attachment { get; set; }
        public virtual DateTime DateSend { get; set; }
        public virtual DateTime DateReceive { get; set; }
    }
}
