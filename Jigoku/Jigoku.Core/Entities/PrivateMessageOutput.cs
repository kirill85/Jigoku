using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jigoku.Core.Entities
{
    public class PrivateMessageOutput : CommonPM
    {
        public virtual int Id { get; private set; }
        public virtual User User { get; set; }
        public virtual DateTime DateSendingMessage { get; set; }
    }
}
