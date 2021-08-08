using Books.API.Filters;
using Books.Business;
using Books.Business.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
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
    public class CategoriesController : Controller
    {
        private ICategoryService service;

        public CategoriesController(ICategoryService categoryService)
        {
            service = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var result = service.GetAllCategories();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "id" })]
        public IActionResult GetById(int id)
        {
            var categoryListResponse = service.GetCategoryById(id);
            if (categoryListResponse != null)
            {
                return Ok(categoryListResponse);
            }

            return NotFound();
        }

        [HttpGet("{categoryId}/books")]
        [AllowAnonymous]
        
        public IActionResult GetBooksOfCategory(int categoryId)
        {
            var response = service.GetBooksByCategoryId(categoryId);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        // gets dto as an input
        public IActionResult AddCategory(AddNewCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                //sends the request to db by using service
                int categoryId = service.AddCategory(request);
                //goes to GetById method - creates link in header 
                return CreatedAtAction(nameof(GetById), routeValues: new { id = categoryId }, value: null);

            }

            return BadRequest(ModelState);
        }

        //IDEMPOTANT- the result of a successfully performed request is independent of the number of times it is executed
        [HttpPut("{id}")]
        [CategoryExists]
        public IActionResult UpdateCategory(int id, EditCategoryRequest request)
        {
            //[CategoryExists] does below part, details --> Filters/CategoryExistsAttribute.cs

            //checking whether id is exist in db or not
            //var isExisting = service.GetCategoryById(id);
            //if (isExisting == null)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                int newItemId = service.UpdateCategory(request);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        //IDEMPOTANT- the result of a successfully performed request is independent of the number of times it is executed
        [HttpDelete("{id}")]
        [CategoryExists]
        public IActionResult Delete(int id)
        {
            service.DeleteCategory(id);
            return Ok();
        }
    }
}
