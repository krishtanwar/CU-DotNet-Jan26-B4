using ValidationProject.Common;

namespace ValidationProject.Exceptions
{
    public class Exceptions
    {
            private readonly RequestDelegate _next;

            public Exceptions(RequestDelegate next)
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
                    context.Response.StatusCode = 500;

                    var response = new ApiResponse<string>
                    {
                        Success = false,
                        Message = ex.Message
                    };

                    await context.Response.WriteAsJsonAsync(response);
                }
            }
        }
    }
