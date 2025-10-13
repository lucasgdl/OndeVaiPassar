using OndeVaiPassar.Domain.Entities.Sports;

namespace OndeVaiPassar.Domain.Interfaces;

public interface ISportRepository
{
    Task<SportEntity?> GetByIdAsync(Guid id);
}
