using AspNetLinq.Excpetions;
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
        catch (CompanyException e)
        {
            _logger.LogError($"Company Exception ocurred: {e.Message}");
            httpContext.Response.StatusCode = 409;
            httpContext.Response.ContentType = "application/json";
            var problemDetail = new ErrorResponse
            {
                Message = e.Message,
                StatusCode = 409,
                Title = "Logic error",
            };
            httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(problemDetail);
        }
        catch (Exception e)
        {
            _logger.LogError($"Unhandled Exception ocurred: {e.Message}");
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