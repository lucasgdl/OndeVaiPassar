using OndeVaiPassar.DTOs;

namespace OndeVaiPassar.Query.Sports;

public interface ISportQueryStore
{
    Task<SportDto?> GetByIdAsync(int id);
    Task<IEnumerable<SportDto>> ListAllAsync();
}
