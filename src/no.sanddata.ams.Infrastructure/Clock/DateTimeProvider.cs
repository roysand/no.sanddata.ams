using no.sanddata.ams.Application.Abstractions.Clock;

namespace no.sanddata.ams.Infrastructure.Clock;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime NowUtc => DateTime.UtcNow;
}
