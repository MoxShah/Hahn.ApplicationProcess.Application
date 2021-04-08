namespace Hahn.ApplicationProcess.February2021.Web.Middleware
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Serilog;

    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    /// <summary>
    /// Middleware to log each request
    /// </summary>
    public class LogMiddleware
    {
        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogMiddleware" /> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="logger">The logger.</param>
        public LogMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invokes the specified HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
                Log.Information($"Request {httpContext.Request?.Method} {httpContext.Request?.Path.Value} Result(Success) => {httpContext.Response?.StatusCode}");
            }
            catch (Exception ex)
            { 
                Log.Error($"Request {httpContext.Request?.Method} {httpContext.Request?.Path.Value} Result(Error) => {ex.GetBaseException()}");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    /// <summary>
    /// 
    /// </summary>
    public static class LogMiddlewareExtensions
    {
        /// <summary>
        /// Uses the log middleware.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
