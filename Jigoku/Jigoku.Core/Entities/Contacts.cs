namespace Jigoku.Core.Entities
{
    public enum ContactType
    {
<<<<<<< HEAD
        Icq = 1,
        Jid = 2,
        Msn = 3,
        MailTo = 4
    }

    public class Contacts : AbstractEntity
    {
        public virtual User Owner { get; set; }
        public virtual ContactType Contact_Type { get; set; }
        public virtual string Value { get; set; }
=======
        public virtual int Id { get; private set; }
        public virtual Person PersonId { get; set; }
        public virtual ContactType Contact_Type { get; set; }
        public virtual string ContactValue { get; set; }
>>>>>>> f2ffab1
    }
}
