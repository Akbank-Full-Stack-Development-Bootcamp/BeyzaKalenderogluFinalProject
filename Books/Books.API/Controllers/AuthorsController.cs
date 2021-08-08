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
    public class AuthorsController : ControllerBase
    {
        private IAuthorService service;
        public AuthorsController(IAuthorService authorService)
        {
            service = authorService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 300)]
        public IActionResult Get()
        {
            var result = service.GetAllAuthors();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "id" })]
        public IActionResult GetById(int id)
        {
            var authorListResponse = service.GetAuthorById(id);
            if (authorListResponse != null)
            {
                return Ok(authorListResponse);
            }

            return NotFound();
        }

        [HttpGet("{authorId}/books")]
        [AllowAnonymous]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "authorId" })]
        public IActionResult GetBooksOfAuthor(int authorId)
        {
            var response = service.GetBooksByAuthorId(authorId);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpGet("search/{name}")]
        [AllowAnonymous]
        public IActionResult SearchAuthors(string name)
        {

            var response = service.SearchAuthor(name);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpPost]
        // gets dto as an input
        public IActionResult AddAuthor(AddNewAuthorRequest request)
        {
            if (ModelState.IsValid)
            {
                //sends the request to db by using service
                int authorId = service.AddAuthor(request);
                //goes to GetById method - creates link in header 
                return CreatedAtAction(nameof(GetById), routeValues: new { id = authorId }, value: null);

            }

            return BadRequest(ModelState);
        }

        //IDEMPOTANT- the result of a successfully performed request is independent of the number of times it is executed
        [HttpPut("{id}")]
        [AuthorExists]
        public IActionResult UpdateAuthor(int id, EditAuthorRequest request)
        {
            //[AuthorExists] does below part, details --> Filters/AuthorExistsAttribute.cs

            //checking whether id is exist in db or not
            //var isExisting = service.GetAuthorById(id);
            //if (isExisting == null)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                int newItemId = service.UpdateAuthor(request);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        //IDEMPOTANT- the result of a successfully performed request is independent of the number of times it is executed
        [HttpDelete("{id}")]
        [AuthorExists]
        public IActionResult Delete(int id)
        {
            service.DeleteAuthor(id);
            return Ok();
        }
    }
}

