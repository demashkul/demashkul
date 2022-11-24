using System.Net;

namespace Web6.Api2.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext,IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext,Exception ex)
        {
            var response = httpContext.Response;
            var StatusCode = (int)HttpStatusCode.InternalServerError;
            response.ContentType = "application/json";
            response.StatusCode = StatusCode;

            await response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
            {
                ex.Message,
                Date = DateTime.UtcNow,
                IsBusiness = true
            }));
        }
    }
}
