using System;
using System.Threading.Tasks;
using MediatorPatternExample.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MediatorPatternExample.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await Handle(exception, context);
            }
        }

        private static async Task Handle(Exception exception, HttpContext context)
        {
            switch (exception)
            {
                case ValueNotFoundException valueNotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync(exception.Message);
                    break;

                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }
        }
    }
}
