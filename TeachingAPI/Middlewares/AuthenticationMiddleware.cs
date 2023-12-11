using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using System;
using System.Threading.Tasks;

namespace ShopAPI.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string secretKey = "aaabbb";
            if (context.Request.Headers.TryGetValue("Raktas", out var key) && key.ToString() == secretKey)
                await this._next(context);
            else
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                ErrorViewModel errorMessage = new ErrorViewModel
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Not authorised",
                };

                context.Response.WriteAsync(errorMessage.ToString());
            }
        }
    }
    public static class LogURLMiddlewareExtensions
    {
        public static IApplicationBuilder AuthenticateUrl(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
