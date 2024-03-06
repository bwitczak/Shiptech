using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Middlewares;

internal sealed class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            var response = context.Response;
            string errorMessage;
            
            switch (e)
            {
                case NotFoundException:
                    errorMessage = e.Message;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case ConflictException:
                    errorMessage = e.Message;
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;
                case BaseException:
                    errorMessage = e.Message;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;;
                    break;
                default:
                    errorMessage = e.Message;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;;
                    break; 
            }
            
            var json = JsonSerializer.Serialize(new {errors = new{CustomExceptionMessage = new List<string>{errorMessage}}});
            await context.Response.WriteAsync(json);
        }
    }
}