using OndeVaiPassar.Domain.Entities.Tournaments;

namespace OndeVaiPassar.Query.Tournaments;

public interface ITournamentQueryStore
{
    Task<TournamentEntity?> GetByIdAsync(long id);
    Task<IEnumerable<TournamentEntity>> GetAllAsync();
}
