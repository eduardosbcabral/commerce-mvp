using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ProjetoMvp.Api.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
#if !DEBUG
            var msg = "An unhandled error occurred.";                
            var stack = string.Empty;
#else
            var msg = context.Exception.GetBaseException().Message;
            var stack = context.Exception.StackTrace;
#endif

            var error = new ApiError(msg, stack);

            context.HttpContext.Response.StatusCode = 500;
            context.Result = new JsonResult(error);
        }
    }

    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public ApiException(
            string message,
            int statusCode = 500) 
            : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class ApiError
    {
        public string Message { get; set; }
        public string Detail { get; set; }

        public ApiError(string message, string detail)
        {
            Message = message;
            Detail = detail;
        }
    }
}
