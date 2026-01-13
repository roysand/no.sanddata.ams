namespace no.sanddata.ams.Domain.Measurements;

public record Unit
{
    public static readonly Unit kWh = new Unit("kWh");
    public static readonly Unit MWh = new Unit("MWh");
    
    public string Value { get; init; }
    
    public static Unit FromValue(string value)
    {
        return All.FirstOrDefault(v => v.Value == value) ??
               throw new ArgumentException($"Invalid unit value: {value}");
    }
    private Unit(string value) => Value = value;
    
    public static readonly IReadOnlyCollection<Unit> All =
    [
        kWh,
        MWh
    ];
}