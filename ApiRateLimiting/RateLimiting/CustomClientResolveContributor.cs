using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Http;

namespace ApiRateLimiting.RateLimiting
{
    public class CustomClientResolveContributor:IClientResolveContributor
    {
        public Task<string> ResolveClientAsync(HttpContext httpContext)
        {
            var customHeaderValue = string.Empty;
            if (httpContext.Request.Headers.TryGetValue("Custom-Header", out var values))
            {
                customHeaderValue = values.First();
            }

            var body = httpContext.Request.Body;

            return Task.FromResult(customHeaderValue);
        }
    }
}