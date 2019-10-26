using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using libraryApi.Dto;
using NHibernate;

namespace libraryApi.Config
{
    public class Database
    {
        private const string ConnectionString = @"Server=books.cyikhgyae21o.sa-east-1.rds.amazonaws.com; Port=3306; User Id=admin; Password=masterkey; Database=booksdb";
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    IPersistenceConfigurer configDB = MySQLConfiguration.Standard.ConnectionString(ConnectionString);
                    var configMap = Fluently.Configure().Database(configDB).Mappings(c => c.FluentMappings.AddFromAssemblyOf<BookDto>());
                    _sessionFactory= configMap.BuildSessionFactory();                    
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
