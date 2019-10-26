using libraryApi.Dto;
using libraryApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace libraryApi.Controllers
{
    [ApiController]
    [Route("api/v1/library/[controller]")]
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
        public StatusCodeResult Post(BookDto book)
        {
            book.Id = new Guid();
            BookRepository.Create(book);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public BookDto Put(Guid id, [FromBody]BookDto book)
        {
            book.Id = id;
            BookRepository.Update(book);
            return BookRepository.Retrieve(book.Id);
        }

        [HttpDelete("{id}")]
        public StatusCodeResult Delete(Guid id)
        {
            BookRepository.Delete(id);
            return StatusCode(204);
        }
    }
}
