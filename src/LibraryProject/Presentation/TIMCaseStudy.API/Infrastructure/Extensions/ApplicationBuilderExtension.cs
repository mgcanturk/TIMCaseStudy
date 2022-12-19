﻿using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using TIMCaseStudy.Common.Infrastructure.Exceptions;
using TIMCaseStudy.Common.Infrastructure.Results;

namespace TIMCaseStudy.API.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtension
    {
         public static void ConfigureExceptionHandler(this WebApplication application)
        {
            application.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {

                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Title = "Internal server error occured!"
                        })); ;
                    }
                });
            });
        }
        //public static IApplicationBuilder ConfigureExceptionHandling(this IApplicationBuilder app,
        //    bool includeExceptionDetails = false,
        //    bool useDefaultHandlingResponse = true,
        //    Func<HttpContext,Exception,Task> handleException = null)
        //{
        //    app.Run(context =>
        //    {
        //        var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
        //        if (!useDefaultHandlingResponse && handleException == null)
        //            throw new ArgumentException(nameof(handleException),
        //                $"{nameof(handleException)} cannot be null when {nameof(useDefaultHandlingResponse)} is false");

        //        if (!useDefaultHandlingResponse && handleException != null)
        //            return handleException(context, exceptionObject.Error);

        //        return DefaultHandleException(context, exceptionObject.Error, includeExceptionDetails);
        //    });
        //    return app;
        //}
        //private static async Task DefaultHandleException(HttpContext context, Exception exception, bool includeExceptionDetails)
        //{
        //    HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        //    string message = "Internal server error occured!";

        //    if(exception is UnauthorizedAccessException)
        //        statusCode = HttpStatusCode.Unauthorized;

        //    if(exception is DatabaseValidationException)
        //    {
        //        var validationResponse = new ValidationResponseModel(exception.Message);
        //        await WriteResponse(context, statusCode, validationResponse);
        //        return;
        //    }

        //    var res = new
        //    {
        //        HttpStatusCode = (int)statusCode,
        //        Detail = includeExceptionDetails ? exception.ToString() : message
        //    };
        //    await WriteResponse(context, statusCode, res);
        //}
        //private static async Task WriteResponse(HttpContext context, HttpStatusCode statusCode, object responseObj)
        //{
        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = (int)statusCode;
        //    await context.Response.WriteAsJsonAsync(responseObj);
        //}
    }
}
