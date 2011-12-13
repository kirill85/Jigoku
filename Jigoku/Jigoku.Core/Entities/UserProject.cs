using System.Collections.Generic;

namespace Jigoku.Core.Entities
{
    public class UserProject
    {
        public virtual int Id { get; private set; }
        public virtual Person Users { get; set; }
        public virtual Project Project { get; set; }
    }
}
