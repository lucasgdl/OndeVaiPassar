using OndeVaiPassar.Domain.Entities.Sports;

namespace OndeVaiPassar.Command.Sports;

public interface ISportCommandStore
{
    Task<int> AddAsync(SportEntity item);
    Task<int> UpdateAsync(SportEntity item);
}
