using Microsoft.AspNetCore.Mvc.Routing;

namespace Healthware.Assist.Core.Utility
{
    public interface IUrlBuilderHelper
    {
        string GetUrlRoot(UrlHelper urlHelper);
    }

    public class UrlBuilderHelper : IUrlBuilderHelper
    {
        public string GetUrlRoot(UrlHelper urlHelper)
        {
            var requestUri = urlHelper.ActionContext.HttpContext.Request;
            return string.Format("{0}://{1}", requestUri.Scheme, requestUri.Host);
        }
    }
}