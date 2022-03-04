using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibApp.Interfaces;
using System.Web.Http;
using System.Net;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        // GET /api/books
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetBooks()
                                .Select(_mapper.Map<Book, BookDto>);

            return Ok(books);
        }

        // GET /api/books/{id}
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookRepository.Get(id);

            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Ok(_mapper.Map<BookDto>(book));
        }

        // POST /api/books
        [HttpPost]
        public IActionResult Add(Book bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.Add(book);
            _bookRepository.Save();
            bookDto.Id = book.Id;

            return CreatedAtRoute(nameof(Get), new { id = bookDto.Id }, bookDto);
        }

        // PUT /api/books
        [HttpPut("{id}")]
        public void Update(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var bookInDb = _bookRepository.Get(id);
            if (bookInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _mapper.Map(bookDto, bookInDb);

            _bookRepository.Save();
        }

        // DELETE /api/books{id}
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (_bookRepository.Get(id) != null)
            {
                _bookRepository.Remove(id);
                _bookRepository.Save();
                return Ok();
            }
            else return NotFound();
        }


        private IMapper _mapper;
    }
}
