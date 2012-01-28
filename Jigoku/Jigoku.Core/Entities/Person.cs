using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Jigoku.Core.Localization;

namespace Jigoku.Core.Entities
{
    public class Person
    {
        public virtual int Id { get; private set; }
		[Required(ErrorMessageResourceType=typeof(Locale_ru_RU), ErrorMessageResourceName="NicknameRequired")]
        public virtual string NickName { get; set; }
		[Required(ErrorMessageResourceName="PasswordRequired", ErrorMessageResourceType=typeof(Locale_ru_RU))]
        public virtual string Password { get; set; }
		[Required(ErrorMessageResourceName="PrimaryMailRequired", ErrorMessageResourceType=typeof(Locale_ru_RU))]
        public virtual string PrimaryMail { get; set; }
        public virtual string UserPhoto { get; set; }//URL gravatar 
        public virtual ISet<Project> Projects { get; set; }

        public Person()
        {
            Projects = new HashSet<Project>();
        }
    }
}
