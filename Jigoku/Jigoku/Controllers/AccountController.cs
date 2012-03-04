using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jigoku.Models;
using Jigoku.ORM.Repository;

namespace Jigoku.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Register()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Register(Person person)
		{
			if (ModelState.IsValid)
			{
				PersonRepository personRepository = new PersonRepository();//получить доступ к репозиторию ОRM
				Jigoku.Core.Entities.Person dbPerson = new Jigoku.Core.Entities.Person{NickName = person.NickName, Password = person.Password, PrimaryMail = person.PrimaryMail, Projects = null, UserPhoto = null}; //создать объект "Пользователь"
				personRepository.Add(dbPerson); //добавить его в БД
				return View("UserInfo", person); //вернуть страницу с информацией о пользователе
			}
			else
			{
				return View("Register");
			}
		}

		private void sendMailPerson(Person person)
		{
			var mailMessage = new System.Net.Mail.MailMessage();
			var mailAddressTo = new System.Net.Mail.MailAddress(person.PrimaryMail);
			mailMessage.Subject = "No reply";
			mailMessage.Body = "Здравствуйте, дорогой (-ая) " + person.NickName + ", вы получили это письмо потому что зарегистрировались на портале Jigoku." + " Если вы не регистрировались у нас, игнорируйте это письмо.";
			mailMessage.Sender = new System.Net.Mail.MailAddress("admin@jigoku.org"); //indian code? hmmm...
			new System.Net.Mail.SmtpClient().Send(mailMessage);
		}
    }
}
