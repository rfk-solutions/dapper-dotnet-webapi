using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace RFK;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILoggerManager _logger;

    public GlobalExceptionHandler(ILoggerManager logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var statusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            BadRequestException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";

        _logger.LogError($"Something went wrong: {exception.Message}");

        await httpContext.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = statusCode,
            Message = exception.Message
        }.ToString(), cancellationToken);

        return true; // Mark exception as fully handled
    }
}