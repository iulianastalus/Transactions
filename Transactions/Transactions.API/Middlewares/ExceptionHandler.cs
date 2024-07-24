namespace Transactions.API.Middlewares;

public class ExceptionHandler : IMiddleware
{
    readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception e)
        {
            _logger.LogError($"{e.Message}\n{e.StackTrace}");
            if (!httpContext.Response.HasStarted)
                await HandleExceptionAsync(httpContext, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception e)
    {
        httpContext.Response.StatusCode = 400;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsync(e.Message);
    }
}
