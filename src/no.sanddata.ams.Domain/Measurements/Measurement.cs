using no.sanddata.ams.Domain.Abstractions;
using no.sanddata.ams.Domain.Locations;

namespace no.sanddata.ams.Domain.Measurements;

public sealed class Measurement :Entity
{
    public DateTime TimeStampUtc { get; private set; }
    public Location Location { get; private set; }
    public Unit Unit { get; private set; }
    public decimal Value { get; private set; }
    
    private Measurement(Guid id, DateTime timeStampUtc, Location location, Unit unit, decimal value)
        : base(id)
    {
        TimeStampUtc = timeStampUtc;
        Location = location;
        Unit = unit;
        Value = value;
    }

    public static Measurement Create(DateTime timeStamp, Location location, Unit unit, decimal value)
    {
        var measurement = new Measurement(Guid.NewGuid(), timeStamp, location, unit, value);
        return measurement;
    }
}