using OndeVaiPassar.Domain.Entities.EventBroadcasts;

namespace OndeVaiPassar.Query.EventBroadcasts;

public interface IEventBroadcastQueryStore
{
    Task<EventBroadcastEntity?> GetByIdAsync(long id);
    Task<IEnumerable<EventBroadcastEntity>> GetAllAsync();
}
