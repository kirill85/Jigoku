namespace Jigoku.Core.Entities
{
    public enum ContactType
    {
<<<<<<< HEAD
=======
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
>>>>>>> 788686b3eeaa9cde891be557deff6020a2976a00
        public virtual int Id { get; private set; }
        public virtual Person Person_Contacts { get; set; }
        public virtual ContactType Contact_Type { get; set; }
        public virtual string ContactValue { get; set; }
<<<<<<< HEAD
=======
>>>>>>> f2ffab1
>>>>>>> 788686b3eeaa9cde891be557deff6020a2976a00
    }
}
