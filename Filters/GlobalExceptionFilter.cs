using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebUI.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            if ("XmlHttpRequest".Equals(context.HttpContext.Request.Headers["X-Requested-With"]))
            {
                GenerateAjaxResponse(context);
                return;
            }
            GenerateHttpResponse(context);
        }

        private void GenerateHttpResponse(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ArgumentNullException:
                case NullReferenceException:
                    context.Result = new ContentResult
                    {
                        Content = File.ReadAllText("wwwroot/error-pages/404.html"),
                        ContentType = "text/html",
                        StatusCode = 200,
                    };
                    break;
                default:
                    context.Result = new ContentResult()
                    {
                        Content = File.ReadAllText("wwwroot/error-pages/500.html"),
                        ContentType = "text/html",
                        StatusCode = 200,
                    };
                    break;

            }
        }

        private void GenerateAjaxResponse(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ArgumentNullException:
                case NullReferenceException:
                default:
                    context.Result = new JsonResult(new
                    {
                        error = true,
                        message = context.Exception.Message
                    });
                    break;
            }
        }
    }
}
