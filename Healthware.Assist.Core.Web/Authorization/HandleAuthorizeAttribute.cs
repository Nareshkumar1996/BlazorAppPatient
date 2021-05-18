using System;
using System.Linq;
using System.Security.Claims;
using Healthware.Assist.Core.Containers;
using Healthware.Assist.Core.Web.Common.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Healthware.Assist.Core.Web.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class HandleAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public HandleAuthorizeAttribute()
        {
            
        }
        public async System.Threading.Tasks.Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                //context.Result = new UnauthorizedResult();
                return;
            }

            // you can also use registered services
            var sessionService = Resolve.AnImplementationOf<ISessionService>();
            var userId = Convert.ToInt64(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            //await sessionService.PollSessionTimeout(userId, 600);
            //var session = sessionService.IsSessionActive(userId).GetAwaiter().GetResult();
            //if (session.WasSuccessful)
            //{
            //   // await sessionService.KeepSessionAlive(userId);
            //}
        }
    }
}