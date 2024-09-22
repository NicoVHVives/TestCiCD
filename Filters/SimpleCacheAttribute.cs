using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class SimpleCacheAttribute : Attribute, IAsyncResourceFilter
    {
        private Dictionary<PathString, IActionResult> cachedResponses =  new();
    
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            PathString path = context.HttpContext.Request.Path;
            if(cachedResponses.ContainsKey(path)) { 
                context.Result = cachedResponses[path];
                cachedResponses.Remove(path);
            }
            else
            {
                ResourceExecutedContext execContext = await next();
                if(execContext != null)
                {
                    cachedResponses.Add(context.HttpContext.Request.Path, execContext.Result);
                }
            }
        }
    }
}
