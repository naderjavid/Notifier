namespace Notifier.Features.Sms.Contracts;

public record SendSmsRequest(string To, string Text);
