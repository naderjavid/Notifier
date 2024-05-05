using Notifier.Features.Email.Contracts;

namespace Notifier.Features.Email;

public static class Endpoints
{

    public static IEndpointRouteBuilder AddEmailEndpoints(this IEndpointRouteBuilder builder) 
    {

        builder.MapPost("/notify/email", 
            async (SendEmailRequest request,
            EmailService emailService) => {

                await emailService.SendAsync(request);


        });
         

        return builder;
    }
}
