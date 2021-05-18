using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;
using Healthware.Assist.Core.Containers;
using Healthware.Assist.Core.Exceptions;
using Healthware.Assist.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Healthware.Assist.Core.Attributes
{
    public class ApiExceptionsHandlerFilterAttribute : ExceptionFilterAttribute
    {
	    private string exceptionDetails = "No additional details are available.";

        public override void OnException(ExceptionContext context)
        {
			var exception = context.Exception ?? new Exception("An unexpected server error has occurred.");
			var exceptionResponse = PrepareFriendlyExceptionResponse(exception, context);

            this.Log().Error(context.Exception);

	        context.Result = exceptionResponse;
	        
	        base.OnException(context);
        }

	    private JsonResult PrepareFriendlyExceptionResponse(Exception exception, ExceptionContext context)
	    {
		    HttpStatusCode statusCode;
		    ApiError apiError = null;

		    if (exception is ApiException)
		    {
			    // handle explicit 'known' API errors
			    var ex = context.Exception as ApiException;
			    context.Exception = null;
			    apiError = new ApiError(ex.Message);
			    apiError.errors = ex.Errors;

			    context.HttpContext.Response.StatusCode = ex.StatusCode;
			    this.Log().Error(ex,ex.GetBaseException().Message);
		    }
			
			else if (exception is UnauthorizedAccessException)
			{
				apiError = new ApiError("Unauthorized Access");
				context.HttpContext.Response.StatusCode = 401;
            
				this.Log().Error(context.Exception,context.Exception.GetBaseException().Message);
			}
            else if (exception is BadRequestObjectResult)
            {
	            context.HttpContext.Response.StatusCode = 400;
	            apiError = new ApiError(exception.Message);
	            apiError.detail = exceptionDetails;
	            this.Log().Error(context.Exception,context.Exception.GetBaseException().Message);
            }
            else
            {
	             // Unhandled errors
            #if !DEBUG
                var msg = "An unexpected server error has occurred.";                
                string stack = null;
            #else
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;
            #endif
	            apiError = new ApiError(msg);
	            apiError.detail = stack;

	            context.HttpContext.Response.StatusCode = 500;
	            this.Log().Error(context.Exception,context.Exception.GetBaseException().Message);

                // handle logging here
            }

	        return new JsonResult(apiError);
	    }

	    private string GetExceptionDetails(Exception exception)
	    {
			//In release mode, we don't want to leak our stack trace, so just give a simple response.
			//This only executes in debug mode and gives a more verbose error by providing a stack trace.
			TryGetDebuggableExceptionDetails(exception); 

		    return exceptionDetails;
	    }

		[Conditional("DEBUG")]
	    private void TryGetDebuggableExceptionDetails(Exception exception)
	    {
		    exceptionDetails = exception.ToString();
	    }
    }
}