using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

public class ExceptionMiddleware
{

    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }



    public async Task Invoke(HttpContext context)
    {

        try
        {

            await _next(context);

        }
        catch(Exception ex)
        {

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Response.ContentType = "application/problem+json";

            ProblemDetails problem = new ProblemDetails()
            { 
            Title = "Internal server error - something went wrong!",
            Detail = ex.Message,
            Status = StatusCodes.Status500InternalServerError,
            Type = "Error"
            };

            var json = JsonSerializer.Serialize(problem);

            await context.Response.WriteAsync(json);

        }

    }

}