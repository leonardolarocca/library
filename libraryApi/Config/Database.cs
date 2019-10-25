using book.Dto;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace book.Config
{
    public static class Database
    {

        private const string ConnectionString = @"Server=books.cyikhgyae21o.sa-east-1.rds.amazonaws.com; Port=3306; User Id=admin; Password=masterkey; Database=booksdb";
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    IPersistenceConfigurer configDb = MySQLConfiguration.Standard.ConnectionString(ConnectionString).ShowSql();
                    var configMap = Fluently
                        .Configure()
                        .Database(configDb)
                        .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<BookDto>()
                        );
                    _sessionFactory = configMap.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
