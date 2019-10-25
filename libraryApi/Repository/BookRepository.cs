using book.Dto;
using FluentNHibernate.Mapping;

namespace book.Repository{
    public class BookRepository : ClassMap<BookDto>
    {
        public BookRepository()
        {
            Id(m => m.Id);
            Map(m => m.Name);
            Map(m => m.Author);
            Map(m => m.ReleaseDate);
            Map(m => m.NumberOfPages);
            Map(m => m.PublishCompany);
            Table("book");
        }
        
    }
}
