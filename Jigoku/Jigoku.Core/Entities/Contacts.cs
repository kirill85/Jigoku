namespace Jigoku.Core.Entities
{
    public class Contacts
    {
        public virtual int Id { get; private set; }
        public virtual ContactType Contact_Type { get; set; }
        public virtual string ContactValue { get; set; }
    }
}
