using OndeVaiPassar.Domain.Entities.Tournaments;

namespace OndeVaiPassar.Command.Tournaments;

public interface ITournamentCommandStore
{
    Task<int> AddAsync(TournamentEntity item);
    Task<int> UpdateAsync(TournamentEntity item);
}
