namespace no.sanddata.ams.Application.Abstractions.Clock;

public interface IDateTimeProvider
{
    DateTime NowUtc { get; }
}