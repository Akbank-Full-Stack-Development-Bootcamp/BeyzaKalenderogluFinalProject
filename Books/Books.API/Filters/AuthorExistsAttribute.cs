using Books.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Filters
{
    public class AuthorExistsAttribute : TypeFilterAttribute
    {
        public AuthorExistsAttribute() : base(typeof(AuthorExistingFilter))
        {

        }

        private class AuthorExistingFilter : IAsyncActionFilter
        {
            private IAuthorService authorService;
            public AuthorExistingFilter(IAuthorService authorService)
            {
                this.authorService = authorService;
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

                var author = authorService.GetAuthorById(id);
                if (author == null)
                {
                    context.Result = new NotFoundObjectResult(new { Message = $" Id {id} cannot found! " });
                    return;
                }

                await next();
            }
        }
    }
    
}
