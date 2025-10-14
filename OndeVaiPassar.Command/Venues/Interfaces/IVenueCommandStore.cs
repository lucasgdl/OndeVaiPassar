using OndeVaiPassar.Domain.Entities.Venues;

namespace OndeVaiPassar.Command.Venues.Interfaces;

public interface IVenueCommandStore
{
    Task<int> CreateAsync(VenueEntity venue);
    Task<int> UpdateAsync(VenueEntity venue);
    Task<int> DeleteAsync(int id);
}
