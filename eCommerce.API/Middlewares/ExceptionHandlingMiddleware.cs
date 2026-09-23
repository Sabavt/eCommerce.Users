namespace eCommerce.API.Middlewares
{ 
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = null!;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger) : this(next)
        {
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("During execution of IActionResult exception occured : {exception}", ex.Message);

                if (ex.InnerException is not null)
                {
                    _logger.LogError($"{ex.InnerException.Message}");
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
