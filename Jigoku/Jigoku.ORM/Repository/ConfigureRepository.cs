using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Jigoku.ORM.Repository
{
    public static class ConfigureRepository
    {
        public static ISessionFactory SessionFactory { get; private set; }

        static ConfigureRepository()
        {
            if (!IsConfigured())
            {
                var nhConfig = new Configuration().Configure();
                SessionFactory = nhConfig.BuildSessionFactory();
                new SchemaExport(nhConfig).Execute(false, true, false);
            }
        }

        private static bool IsConfigured()
        {
            return (SessionFactory != null);
        }
    }
}
