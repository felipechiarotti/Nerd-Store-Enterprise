using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpcontext)
        {
            try
            {
                await _next(httpcontext);
            }catch(CustomHttpRequestException ex)
            {
                HandleRequestExceptionAsync(httpcontext, ex);
            }
        }

        private static void HandleRequestExceptionAsync(HttpContext context, CustomHttpRequestException httpRequestException)
        {
            if(httpRequestException.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                context.Response.Redirect("/login");
                return;
            }
            context.Response.StatusCode = (int)httpRequestException.StatusCode;
        }
    }
}
