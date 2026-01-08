namespace no.sanddata.ams.Domain.Locations;

public interface ILocationRepository
{
    Task<Location?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}