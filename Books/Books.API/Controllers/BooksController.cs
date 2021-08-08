using Books.API.Filters;
using Books.Business;
using Books.Business.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private IBookService service;
        public BooksController(IBookService bookService)
        {
            service = bookService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 300)]
        public IActionResult Get()
        {
            var result = service.GetAllBooks();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "id" })]
        public IActionResult GetById(int id)
        {
            var bookListResponse = service.GetBookById(id);
            if (bookListResponse != null)
            {
                return Ok(bookListResponse);
            }

            return NotFound();
        }

        [HttpGet("{id}/detail")]
        [AllowAnonymous]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "id" })]
        public IActionResult GetBookDetailById(int id)
        {
            var bookDetailResponse = service.GetBookDetailById(id);
            if (bookDetailResponse != null)
            {
                return Ok(bookDetailResponse);
            }

            return NotFound();
        }

        [HttpGet("search/{title}")]
        [AllowAnonymous]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "title" })]
        public IActionResult SearchBooks(string title)
        {

            var response = service.SearchBook(title);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpPost]
        // gets dto as an input
        public IActionResult AddBook(AddNewBookRequest request)
        {
            if (ModelState.IsValid)
            {
                //sends the request to db by using service
                int bookId = service.AddBook(request);
                //goes to GetById method - creates link in header 
                return CreatedAtAction(nameof(GetById), routeValues: new { id = bookId }, value: null);

            }

            return BadRequest(ModelState);
        }

        //IDEMPOTANT- the result of a successfully performed request is independent of the number of times it is executed
        [HttpPut("{id}")]
        [BookExists]
        public IActionResult UpdateBook(int id, EditBookRequest request)
        {
            //[BookExists] does below part, details --> Filters/BookExistsAttribute.cs

            //checking whether id is exist in db or not
            //var isExisting = service.GetBookById(id);
            //if (isExisting == null)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                int newItemId = service.UpdateBook(request);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        //IDEMPOTANT- the result of a successfully performed request is independent of the number of times it is executed
        [HttpDelete("{id}")]
        [BookExists]
        public IActionResult Delete(int id)
        {
            service.DeleteBook(id);
            return Ok();
        }
    }
}
