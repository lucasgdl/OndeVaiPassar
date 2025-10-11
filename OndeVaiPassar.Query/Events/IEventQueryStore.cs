using OndeVaiPassar.Domain.Entities.Event;

namespace OndeVaiPassar.Query.Events;

public interface IEventQueryStore
{
    Task<EventEntity?> GetByIdAsync(long id);
    Task<IEnumerable<EventEntity>> GetAllAsync();
}
