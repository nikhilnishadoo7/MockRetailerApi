namespace MockRetailerApi.Middleware;

public class ApiHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public ApiHeaderMiddleware(
        RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(
        HttpContext context)
    {
        var apiKey =
            context.Request.Headers["x-api-key"]
            .ToString();

        var auth =
            context.Request.Headers["authorization"]
            .ToString();

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            context.Response.StatusCode = 401;

            await context.Response.WriteAsJsonAsync(
                new
                {
                    resultCode = "401",
                    resultStatus = "ERR",
                    resultMessage =
                        "Invalid x-api-key"
                });

            return;
        }

        if (string.IsNullOrWhiteSpace(auth))
        {
            context.Response.StatusCode = 401;

            await context.Response.WriteAsJsonAsync(
                new
                {
                    resultCode = "401",
                    resultStatus = "ERR",
                    resultMessage =
                        "Invalid authorization token"
                });

            return;
        }

        await _next(context);
    }
}