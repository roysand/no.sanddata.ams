using System.Diagnostics.CodeAnalysis;
using no.sanddata.ams.Application.Abstractions.Email;

namespace no.sanddata.ams.Infrastructure.Email;

[SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "Instantiated by DI container")]

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}
