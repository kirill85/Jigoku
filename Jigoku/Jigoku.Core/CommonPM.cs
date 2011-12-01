using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jigoku.Core
{
    public class CommonPM
    {
        public virtual string Topic { get; set; }
        public virtual byte[] Attachment { get; set; }
        public virtual string BodyMessage { get; set; }
    }
}
