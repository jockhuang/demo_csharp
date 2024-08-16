using Demo.Model;

namespace Demo.Controllers;

public class ExceptionHandlerMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (UnauthorizedAccessException)
        {
            // Handle unauthorized access
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new ApiResponse { Code = -1, Message = "Unauthorized access." });
        }
        catch (Exception ex)
        {
            // Handle other unhandled exceptions
            // Log the exception for debugging purposes.
            Console.WriteLine($"Unhandled Exception: {ex}");

            // Customize the error response as needed.
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new ApiResponse
                { Code = -1, Message = $"An error occurred while processing your request({ex.Message})." });
        }
    }
}