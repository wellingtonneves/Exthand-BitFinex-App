using Best.Buy.API.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace Best.Buy.API.Attributes
{
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
        {

            var appConfig = (AppConfig)context.HttpContext.RequestServices.
            GetService(typeof(AppConfig));

            if (!context.HttpContext.Request.Query.TryGetValue(appConfig.KeyName, 
                out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApiKey not found"
                };
                return;
            }

            if (!appConfig.ApiKey.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "Forbidden"
                };
                return;
            }

            await next();
        }
    }
}
