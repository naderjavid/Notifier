namespace Notifier.Features.Email.Contracts;

public record SendEmailRequest (
    string Subject,
    string To,
    string Content);