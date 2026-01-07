using System.Runtime.CompilerServices;
using no.sanddata.ams.Domain.Abstractions;

namespace no.sanddata.ams.Domain.Locations;

public sealed class Location : Entity
{
    public Name Name { get; private set; }
    public Address Address { get; private set; }
    public SerialNumber SerialNumber { get; private set; }
    public Zone Zone { get; private set; }
    public bool IsActive { get; private set; }
    public bool HasNorgesPriceAgreement { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }
    public DateTime ModifiedAtUtc { get; private set; }

    public Location(Guid id, Name name, Address address, SerialNumber serialNumber, Zone zone
        , bool isActive = false, bool hasNorgesPriceAgreement = false)
        : base(id)
    {
        Name = name;
        Address = address;
        SerialNumber = serialNumber;
        Zone = zone;
        IsActive = isActive;
        HasNorgesPriceAgreement = hasNorgesPriceAgreement;
        CreatedAtUtc = DateTime.UtcNow;
        ModifiedAtUtc = DateTime.UtcNow;
    }
}
