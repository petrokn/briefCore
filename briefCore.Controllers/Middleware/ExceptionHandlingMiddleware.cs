﻿namespace briefCore.Controllers.Middleware
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using log4net;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    public class ExceptionHandlingMiddleware
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ExceptionHandlingMiddleware));
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            //if (exception is Exception)
            //{
            //    code = HttpStatusCode.NotFound;
            //}

            _logger.Error(exception.Message);
            
            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}