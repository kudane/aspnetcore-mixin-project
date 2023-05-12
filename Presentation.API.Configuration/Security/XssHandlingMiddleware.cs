namespace Presentation.API.Configuration
{
    public class XssHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public XssHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check XSS in URL
            if (!string.IsNullOrWhiteSpace(context.Request.Path.Value))
            {
                var url = context.Request.Path.Value;

                if (IsDangerousString(url))
                {
                    throw new Exception("BadRequest Invalid Character");
                }
            }

            // Check XSS in query string
            if (!string.IsNullOrWhiteSpace(context.Request.QueryString.Value))
            {
                var queryString = WebUtility.UrlDecode(context.Request.QueryString.Value);

                if (IsDangerousString(queryString))
                {
                    throw new Exception("BadRequest Invalid Character");
                }
            }

            // Check XSS in request content
            var originalBody = context.Request.Body;
            try
            {
                var content = await ReadRequestBody(context);

                if (content.IndexOf("file") == -1)
                {
                    if (IsDangerousString(content))
                    {
                        throw new Exception("BadRequest Invalid Character");
                    }
                }

                await next(context);
            }
            finally
            {
                context.Request.Body = originalBody;
            }
        }

        private static async Task<string> ReadRequestBody(HttpContext context)
        {
            using (var buffer = new MemoryStream())
            {
                await context.Request.Body.CopyToAsync(buffer);
                context.Request.Body = buffer;
                context.Request.Body.Position = 0;
                using (var stream = new StreamReader(buffer, Encoding.UTF8))
                {
                    return await stream.ReadToEndAsync();
                }
            }
        }

        private static bool IsDangerousString(string s)
        {
            s = s.ToLower();

            if (s.IndexOf("<script") != -1)
            {
                return true;
            }

            if (s.IndexOf("onerror") != -1)
            {
                return true;
            }

            if (s.IndexOf("onclick") != -1)
            {
                return true;
            }

            if (s.IndexOf("&#") != -1)
            {
                return true;
            }

            return false;
        }
    }
}
