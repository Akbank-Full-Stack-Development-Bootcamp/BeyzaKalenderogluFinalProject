using Books.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Filters
{
    public class CategoryExistsAttribute : TypeFilterAttribute
    {
        public CategoryExistsAttribute() : base(typeof(CategoryExistingFilter))
        {
            
        }

        private class CategoryExistingFilter : IAsyncActionFilter
        {
            private ICategoryService categoryService;
            public CategoryExistingFilter(ICategoryService categoryService)
            {
                this.categoryService = categoryService;
            }
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!context.ActionArguments.ContainsKey("id"))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                if (!(context.ActionArguments["id"] is int id))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var category = categoryService.GetCategoryById(id);
                if (category == null)
                {
                    context.Result = new NotFoundObjectResult(new { Message = $" Id {id} cannot found! " });
                    return;
                }

                await next();
            }
        }
    }
}
