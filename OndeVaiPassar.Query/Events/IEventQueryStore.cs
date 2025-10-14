using OndeVaiPassar.Domain.Entities.Events;

namespace OndeVaiPassar.Query.Events;

public interface IEventQueryStore
{
    Task<EventEntity?> GetByIdAsync(long id);
    Task<IEnumerable<EventEntity>> GetAllAsync();
}
