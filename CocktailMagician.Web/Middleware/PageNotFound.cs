using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CocktailMagician.Web.Middleware
{
    public class PageNotFound
    {
        private readonly RequestDelegate next;

        public PageNotFound(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            await this.next.Invoke(httpContext);

            if (httpContext.Response.StatusCode == 404)
            {
                httpContext.Response.Redirect("/Home/PageNotFound");
            }
        }
    }
}
