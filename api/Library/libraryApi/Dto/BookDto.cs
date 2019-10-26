using System;

namespace libraryApi.Dto
{
    public class BookDto
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Author { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual int NumberOfPages { get; set; }
        public virtual string PublishCompany { get; set; }
    }
}
