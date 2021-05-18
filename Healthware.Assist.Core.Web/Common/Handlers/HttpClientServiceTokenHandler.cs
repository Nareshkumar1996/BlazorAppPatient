using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Healthware.Assist.Core.Web.Common.HttpClient;

namespace Healthware.Assist.Core.Web.Common.Handlers
{
    public class HttpClientServiceTokenHandler : DelegatingHandler
    {
        private readonly IHttpClientService _clientService;

        public HttpClientServiceTokenHandler(
            IHttpClientService clientService)
        {
            _clientService = clientService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // request the access token
          //  var accessToken = await _clientService.RequestClientCredentialsTokenAsync();

            // set the bearer token to the outgoing request
          //  request.Headers.Add("token", accessToken);

            // Proceed calling the inner handler, that will actually send the request
            // to our protected api
            return await base.SendAsync(request, cancellationToken);
        }
    }
}