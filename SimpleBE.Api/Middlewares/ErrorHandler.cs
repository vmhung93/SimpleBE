using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleBE.Api.Middlewares
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandler(RequestDelegate next, ILogger<ErrorHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception?.Message);

                var response = context.Response;
                response.ContentType = "application/json";

                switch (exception)
                {
                    case ValidationException ve:
                    case ApplicationException ae:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var message = JsonSerializer.Serialize(new { message = exception?.Message });
                await response.WriteAsync(message);
            }
        }
    }
}