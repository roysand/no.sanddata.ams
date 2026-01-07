namespace no.sanddata.ams.Domain.Locations;

public record Address(
    string Street,
    string City,
    string State,
    string ZipCode,
    string Country);
