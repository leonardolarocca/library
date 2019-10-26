using FluentNHibernate.Mapping;
using libraryApi.Dto;

namespace libraryApi.Repository
{
    public class BookRepository : ClassMap<BookDto>
    {
        public BookRepository()
        {
            Id(m => m.Id, "id");
            Map(m => m.Name, "name");
            Map(m => m.Author, "author");
            Map(m => m.ReleaseDate, "release_date");
            Map(m => m.NumberOfPages, "number_of_pages");
            Map(m => m.PublishCompany, "publish_company");
            Table("book");
        }
    }
}
