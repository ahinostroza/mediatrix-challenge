namespace SB.TechnicalChallenge.Presentation.Extensions;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using SB.TechnicalChallenge.Domain;

[ExcludeFromCodeCoverage]
public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        _ = app.UseExceptionHandler(appError => appError.Run(async context =>
        {
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

            if (contextFeature != null)
            {
                var statusCode = contextFeature.Error switch
                {
                    ValidationException ex => HttpStatusCode.BadRequest,
                    SBTechnicalChallengeException ex => HttpStatusCode.BadRequest,
                    _ => HttpStatusCode.InternalServerError
                };

                var apiError = new ApiError([contextFeature.Error.Message], contextFeature.Error.InnerException?.Message, contextFeature.Error.StackTrace);

                if (contextFeature.Error.GetType() == typeof(SBTechnicalChallengeException))
                {
                    var errors = ((FluentValidation.ValidationException)contextFeature.Error.InnerException).Errors.Select(x => x.ErrorMessage).ToArray();
                    apiError.Messages = errors;
                }

                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";


                await context.Response.WriteAsync(JsonSerializer.Serialize(apiError));
            }
        }));

        return app;
    }
}
