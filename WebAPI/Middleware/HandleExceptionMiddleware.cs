using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Common.Exceptions;

namespace WebAPI.Middleware
{
    public class HandleExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HandleExceptionMiddleware> _logger;

        public HandleExceptionMiddleware(RequestDelegate next, ILogger<HandleExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
           try
            {
                await _next(context);
            }
            catch (EntityAlreadyExistException uaex)
            {
                _logger.LogError(uaex, "EntityAlreadyExistException occured");
                await ReturnErrorAsync(context, uaex.PublicMessage, uaex.ReturnStatusCode);
            }
            catch (EntityNotFoundException enfx)
            {
                _logger.LogError(enfx, "EntityNotFoundException occured");
                await ReturnErrorAsync(context, enfx.PublicMessage, enfx.ReturnStatusCode);
            }
            catch (InvalidFormException ifex)
            {
                _logger.LogError(ifex, "InvalidFormException occured");
                await ReturnErrorAsync(context, ifex.PublicMessage, ifex.ReturnStatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured");
                await ReturnErrorAsync(context, "Internal Server Errror");
            }
            //finally
            //{
            //    // 
            //}

        }

        private async static Task ReturnErrorAsync(HttpContext context, string message, int statusCode = StatusCodes.Status500InternalServerError)
        {
            context.Response.ContentType="application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(message);
        }


    }
}
