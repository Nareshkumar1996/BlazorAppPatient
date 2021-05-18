using System;
using Healthware.Assist.Core.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Healthware.Assist.Core.Web.Logging
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class LogAttribute : ActionFilterAttribute
    {
        public LogAttribute()
        {

        }
        public override void OnActionExecuted(ActionExecutedContext actionContext)
        {
            this.Log().Informational("Action Method: " + actionContext.HttpContext.Request.Method + ":" + actionContext.ActionDescriptor.DisplayName + Environment.NewLine + "Date Time" + DateTime.Now.ToShortDateString() + Environment.NewLine + "Request URL: " + actionContext.HttpContext.Request.Path);
        }
        public override void OnActionExecuting(ActionExecutingContext actionExecutedContext)
        {
            this.Log().Informational("Action Method: " + actionExecutedContext.HttpContext.Request.Method + ":" + actionExecutedContext.ActionDescriptor.DisplayName + Environment.NewLine + "Date Time" + DateTime.Now.ToShortDateString() + Environment.NewLine + "Request URL: " + actionExecutedContext.HttpContext.Request.Path);
        }
    }
}