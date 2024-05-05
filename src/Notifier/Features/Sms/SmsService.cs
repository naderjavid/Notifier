using Microsoft.Extensions.Options;
using Notifier.Features.Sms.Contracts;
using PayamakCore.Interface;

namespace Notifier.Features.Sms;

internal class SmsService(IPayamakServices  payamakService, IOptions<AppSettings> options)
{
    internal Task SendAsync(SendSmsRequest request)
    {
        var a = payamakService.SendSms(new PayamakCore.Dto.MessageDto
        {
            From = "50001270121212",
            IsFlash = false,
            Text = request.Text,
            To = request.To,
            password = options.Value.SmsPassword,
            username = options.Value.SmsUserName
        });
 
        return Task.CompletedTask ;
    }
}