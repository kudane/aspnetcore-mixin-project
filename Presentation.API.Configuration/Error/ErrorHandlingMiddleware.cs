namespace Presentation.API.Configuration
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                string? result = null;
                switch (ex)
                {
                    case Exception e:
                        logger.LogError(e, "Unhandled Exception");
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        result = JsonSerializer.Serialize(new
                        {
                            errors = "An Internal Error Has Occurred."
                        });
                        break;
                }
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result ?? "{}");
            }
        }
    }
}
