using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using FileAPI.Models;

namespace FileAPI.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this._next(context);
            }
            catch (NullReferenceException e)
            {
                ErrorViewModel errorMessage = new ErrorViewModel(
                    "Not found " + e.Source,
                    StatusCodes.Status404NotFound
                    );

                context.Response.StatusCode = errorMessage.StatusCode;
                await context.Response.WriteAsync(errorMessage.ToString());
            }
            catch (Exception e)
            {
                ErrorViewModel errorMessage = new ErrorViewModel(
                    e.Message,
                    StatusCodes.Status500InternalServerError
                    );

                context.Response.StatusCode = errorMessage.StatusCode;
                await context.Response.WriteAsync(errorMessage.ToString());
            }
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder ErrorHandleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}
