using OndeVaiPassar.Domain.Entities.Sports;

namespace OndeVaiPassar.Query.Sports;

public interface ISportQueryStore
{
    Task<SportEntity?> GetByIdAsync(long id);
    Task<IEnumerable<SportEntity>> GetAllAsync();
}
