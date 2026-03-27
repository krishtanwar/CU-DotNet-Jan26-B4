using System.Net;

namespace WebApplication1.Exceptions
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var code = (int)HttpStatusCode.InternalServerError;

                if (ex is NotFoundException)
                    code = (int)HttpStatusCode.NotFound;
                else if (ex is BadRequestException)
                    code = (int)HttpStatusCode.BadRequest;

                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = (int)code;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
