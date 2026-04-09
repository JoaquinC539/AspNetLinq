using Microsoft.AspNetCore.Mvc;

namespace AspNetLinq.Middleware;

public class ExceptionHandlerMiddleware
{
    public class ErrorResponse
    {
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public string Title { get; set; } = string.Empty;
    }
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            _logger.LogError($"Exception ocurred: {e.Message}");
            var problemDetail = new ErrorResponse
            {
                Message = e.Message,
                StatusCode = 500,
                Title = "Internal Server Error",
            };
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(problemDetail);
        }
    }
}