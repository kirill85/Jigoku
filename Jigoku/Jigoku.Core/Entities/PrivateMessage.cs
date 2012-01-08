using System;

namespace Jigoku.Core.Entities
{
    public class PrivateMessage
    {
        public virtual int Id { get; private set; }
        public virtual Person PersonFrom { get; set; }
        public virtual Person PersonTo { get; set; }
        public virtual string Topic { get; set; }
        public virtual DateTime DateSend { get; set; }
        public virtual string Body { get; set; }
        public virtual byte[] Attachment { get; set; }
    }
}
