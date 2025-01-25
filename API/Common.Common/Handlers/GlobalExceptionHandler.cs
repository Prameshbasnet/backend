using Common.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Net.Mime;
using System.Net;
using System.Text.Json;
using Common.Common.Response;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Common.Common.Handlers
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private readonly IHostEnvironment _env;
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly string _serviceName;

        public GlobalExceptionHandler(
              IHostEnvironment env,
              ILogger<GlobalExceptionHandler> logger,
              string serviceName)
        {
            _env = env;
            _logger = logger;
            _serviceName = serviceName;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            if (ex is ResourceNotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                statusCode = HttpStatusCode.NotFound;
            }
            else if (ex is UniqueConstraintViolationException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (ex is GuidParseException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (ex is DbUpdateException)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                statusCode = HttpStatusCode.InternalServerError;
            }

            var response = _env.IsDevelopment()
                ? new APIResponse(false, statusCode, ex.Message, ex.StackTrace?.ToString())
                : new APIResponse(false, statusCode, ex.Message
                        .TrimStart("One or more errors occurred. (".ToCharArray())
                        .TrimEnd(")".ToCharArray()), Message.ERROR);

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);

            _logger.LogError(ex, "An error occurred. Status code: {StatusCode}, Message: {@Message}", statusCode, ex.InnerException);

            await context.Response.WriteAsync(json);
        }
    }
}
