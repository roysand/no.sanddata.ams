using no.sanddata.ams.Application.Abstractions.Email;

namespace no.sanddata.ams.Infrastructure.Email;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}
