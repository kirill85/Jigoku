using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jigoku.Core
{
    public abstract class AbstractEntity
    {
        public virtual int Uid { get; protected set; }
    }
}
