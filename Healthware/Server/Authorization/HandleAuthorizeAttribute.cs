using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Healthware.Server.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class HandleAuthorizeAttribute: AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public HandleAuthorizeAttribute()
        {
            
        }
        public async System.Threading.Tasks.Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                return;
            }
        }   
    }
}
