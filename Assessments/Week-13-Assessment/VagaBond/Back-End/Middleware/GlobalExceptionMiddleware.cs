using Azure;
using System.Net;
using System.Text.Json;
namespace Back_End.Middleware
{
    public class GlobalExceptionMiddleware
    {

            private readonly RequestDelegate _next;
            private readonly ILogger<GlobalExceptionMiddleware> _logger;

            public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
            {
                _next = next;
                _logger = logger;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                
            catch(InvalidRatingException  ex)
            {
                _logger.LogError(ex, "Unhandled Exception Occurred");
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new
                {
                    message = "Rating Must be between 1-5"
                });

                await context.Response.WriteAsync(result);
            }
            catch(DestinationNotFound ex)
            {
                _logger.LogError(ex, "Unhandled Exception Occurred");
                context.Response.StatusCode = 404;
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new
                {
                    message = "Entered Destination is not Found"
                });

                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception Occurred");

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    message = "Something went wrong!"
                });

                await context.Response.WriteAsync(result);
            }
        }
        }
    }
