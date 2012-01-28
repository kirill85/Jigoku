using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jigoku.Core.Entities;

namespace Jigoku.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
		[HttpGet]
        public ActionResult Register()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Register(Person person)
		{
			if (ModelState.IsValid)
			{
				return View("LogOn", person);
			}
			else
			{
				return View();
			}
		}
    }
}
