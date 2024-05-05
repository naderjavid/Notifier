using Notifier.Features.Sms.Contracts;

namespace Notifier.Features.Sms;

public static class Endpoints
{

    public static IEndpointRouteBuilder AddSmsEndpoints(this IEndpointRouteBuilder builder)
    {

        builder.MapPost("/notify/sms",
            async (SendSmsRequest request,
            SmsService smsService) =>
            {
                await smsService.SendAsync(request);
            });


        return builder;
    }
}
