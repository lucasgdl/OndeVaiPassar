using OndeVaiPassar.Domain.Entities.Venues;

namespace OndeVaiPassar.Domain.Interfaces;

public interface IVenueRepository
{
    Task<VenueEntity?> GetByIdAsync(int id);
}
