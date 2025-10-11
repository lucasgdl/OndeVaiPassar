using OndeVaiPassar.Domain.Entities.Event;

namespace OndeVaiPassar.Command.Events;

public interface IEventCommandStore
{
    Task<int> AddAsync(EventEntity item);
    Task<int> UpdateAsync(EventEntity item);
}
