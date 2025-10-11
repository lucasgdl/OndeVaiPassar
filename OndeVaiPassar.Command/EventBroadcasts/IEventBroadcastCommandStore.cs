using OndeVaiPassar.Domain.Entities.EventBroadcasts;

namespace OndeVaiPassar.Command.EventBroadcasts;

public interface IEventBroadcastCommandStore
{
    Task<int> AddAsync(EventBroadcastEntity item);
    Task<int> UpdateAsync(EventBroadcastEntity item);
}
