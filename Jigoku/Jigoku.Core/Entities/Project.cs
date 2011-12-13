using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jigoku.Core.Entities
{
    public class Project
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string SiteUrl { get; set; }
        public virtual string TrackerUrl { get; set; }
        public virtual string License { get; set; }
        public virtual string Tags { get; set; }
    }
}
