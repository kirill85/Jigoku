using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;

namespace Jigoku.ORM.Repository
{
    public static class ConfigureRepository
    {
        public static ISessionFactory SessionFactory { get; private set; }

        public static void Init()
        {
            if (!IsConfigured())
            {
                var nhConfig = new Configuration().Configure();
                SessionFactory = nhConfig.BuildSessionFactory();
            }
        }

        public static bool IsConfigured()
        {
            return (SessionFactory != null);
        }
    }
}
