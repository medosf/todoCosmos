public class CheckCookieMiddleware
{
    private readonly RequestDelegate _next;

    public CheckCookieMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        // Check for the presence of a specific cookie
        if (context.Request.Method.Equals("POST") && !context.Request.Cookies.TryGetValue("testCookie", out var cookieValue))
        {
            // If the cookie is not present, return a 401 Unauthorized response
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized: Cookie not found.");
            return;
        }

        // If the cookie is present, continue processing the request
        await _next(context);
    }
}
