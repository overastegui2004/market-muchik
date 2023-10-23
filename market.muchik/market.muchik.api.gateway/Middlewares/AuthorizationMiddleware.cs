using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using market.muchik.infra.crosscutting.Models;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace market.muchik.api.gateway.Middlwares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);

            if (httpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                httpContext.Response.ContentType = "application/json";
                var response = httpContext.Response;

                var exceptionResponseModel = new ExceptionResponseModel();
                exceptionResponseModel.StatusCode = (int)HttpStatusCode.Unauthorized;
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                exceptionResponseModel.Message = "Token Validation Has Failed. Request Access Denied";
                
                var exResult = JsonSerializer.Serialize(exceptionResponseModel);
                await httpContext.Response.WriteAsync(exResult);
            }

            if (httpContext.Response.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                httpContext.Response.ContentType = "application/json";
                var response = httpContext.Response;

                var exceptionResponseModel = new ExceptionResponseModel();
                exceptionResponseModel.StatusCode = (int)HttpStatusCode.Unauthorized;
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                exceptionResponseModel.Message = "You don't have permission to access, the role don't have permission to access.";

                var exResult = JsonSerializer.Serialize(exceptionResponseModel);
                await httpContext.Response.WriteAsync(exResult);
            }
        }
    }
}
