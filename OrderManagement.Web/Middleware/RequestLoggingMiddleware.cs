using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OrderManagement.Web.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            _logger.LogInformation($"🟢 Incoming Request: {context.Request.Method} {context.Request.Path}");

            await _next(context); // Przekazanie do następnego middleware

            stopwatch.Stop();
            _logger.LogInformation($"🛑 Response Status: {context.Response.StatusCode} ({stopwatch.ElapsedMilliseconds}ms)");
        }
    }
}
