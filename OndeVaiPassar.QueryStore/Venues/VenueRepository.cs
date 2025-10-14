using OndeVaiPassar.Domain.Entities.Venues;
using OndeVaiPassar.Domain.Interfaces;

namespace OndeVaiPassar.QueryStore.Venues
{
    public class VenueRepository : IVenueRepository
    {
        private readonly AppDbContext _context;

        public VenueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VenueEntity?> GetByIdAsync(int id) =>
            await _context.Venues.FirstOrDefaultAsync(x => x.Id == id);
    }
}
