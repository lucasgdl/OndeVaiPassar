using OndeVaiPassar.Domain.Entities.Broadcasters;

namespace OndeVaiPassar.Query.Broadcasters;

public interface IBroadcasterQueryStore
{
    Task<BroadcasterEntity?> GetByIdAsync(long id);
    Task<IEnumerable<BroadcasterEntity>> GetAllAsync();
}
