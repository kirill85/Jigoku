using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace Jigoku
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ///<Bug annotation 2>
            ///I guess this part is necessary and we can't colse it as an optional debug option, so I mask
            ///#if _MyDEBUG #endif
            ///And there is a new bug coming here
            ///Could not determine type for: Jigoku.Core.Entities.text, Jigoku.Core, for columns: NHibernate.Mapping.Column(NickName)
            ///</Bug annotation 2>
            var nhConfig = new Configuration().Configure();
            SessionFactory = nhConfig.BuildSessionFactory();
        }

        protected void Application_BeginRequest(object sender, EventArgs args)
        {
            ///<Bug annotation>
            ///BUG : Object reference not set to an instance of an object.
            ///Buildable but fails on run.
            ///</Bug annotation>
            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }

        protected void Application_EndRequest(object sender, EventArgs args)
        {
            var session = CurrentSessionContext.Unbind(SessionFactory);
            session.Dispose();
        }

        public static ISessionFactory SessionFactory { get; private set; }
    }
}