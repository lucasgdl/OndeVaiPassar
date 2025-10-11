using OndeVaiPassar.Domain.Entities.Broadcasters;

namespace OndeVaiPassar.Command.Broadcasters;

public interface IBroadcasterCommandStore
{
    Task<int> AddAsync(BroadcasterEntity item);
    Task<int> UpdateAsync(BroadcasterEntity item);
}
