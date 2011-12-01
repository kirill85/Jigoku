using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jigoku.Core.Entities
{
    public class PrivateMessage
    {
        public virtual int Id { get; private set; }
        public virtual IList<PrivateMessageOutput> PrivateMessageOutput { get; set; }
        public virtual IList<PrivateMessageInput> PrivateMessageInput { get; set; }
    }
}
