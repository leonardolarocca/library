using book.Dto;
using book.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace book.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepositoryBase<BookDto> BookRepository;

        public BookController(IRepositoryBase<BookDto> BookRepository)
        {
            this.BookRepository = BookRepository;
        }

        [HttpGet]
        public IList<BookDto> Get()
        {
            return BookRepository.RetrieveAll();
        }

        [HttpGet("{id}")]
        public BookDto Get(Guid id)
        {
            return BookRepository.Retrieve(id);
        }

        [HttpPost]
        public void Post(BookDto book)
        {
            BookRepository.Create(book);
        }

        [HttpPut]
        public void Put(BookDto book)
        {
            BookRepository.Update(book);
        }

        [HttpDelete("{id}")]
        public void Delete(BookDto book)
        {
            BookRepository.Delete(book);
        }
    }
}
