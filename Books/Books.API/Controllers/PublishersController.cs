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
    public class PublishersController : ControllerBase
    {
        private IPublisherService service;
        public PublishersController(IPublisherService publisherService)
        {
            service = publisherService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 300)]
        public IActionResult Get()
        {
            var result = service.GetAllPublishers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "id" })]
        public IActionResult GetById(int id)
        {
            var authorListResponse = service.GetPublisherById(id);
            if (authorListResponse != null)
            {
                return Ok(authorListResponse);
            }

            return NotFound();
        }

        [HttpGet("{publisherId}/books")]
        [AllowAnonymous]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "publisherId" })]
        public IActionResult GetBooksOfPublisher(int publisherId)
        {
            var response = service.GetBooksByPublisherId(publisherId);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpGet("search/{title}")]
        [AllowAnonymous]
        public IActionResult SearchPublishers(string title)
        {

            var response = service.SearchPublisher(title);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpPost]
        // gets dto as an input
        public IActionResult AddPublisher(AddNewPublisherRequest request)
        {
            if (ModelState.IsValid)
            {
                //sends the request to db by using service
                int publisherId = service.AddPublisher(request);
                //goes to GetById method - creates link in header 
                return CreatedAtAction(nameof(GetById), routeValues: new { id = publisherId }, value: null);

            }

            return BadRequest(ModelState);
        }

        //IDEMPOTANT- the result of a successfully performed request is independent of the number of times it is executed
        [HttpPut("{id}")]
        [PublisherExists]
        public IActionResult UpdatePublisher(int id, EditPublisherRequest request)
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
                int newItemId = service.UpdatePublisher(request);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        //IDEMPOTANT- the result of a successfully performed request is independent of the number of times it is executed
        [HttpDelete("{id}")]
        [PublisherExists]
        public IActionResult Delete(int id)
        {
            service.DeletePublisher(id);
            return Ok();
        }
    }
}
