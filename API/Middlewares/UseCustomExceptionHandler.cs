using CORE.DTOs;
using Microsoft.AspNetCore.Diagnostics;
using SERVICE.Exceptions;
using System.Text.Json;

namespace API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(async config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeautre = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeautre.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;
                    var response = CustomResponseDto<NoContentDto>.Fail(context.Response.StatusCode,exceptionFeautre.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });

            });
        }
    }
}
