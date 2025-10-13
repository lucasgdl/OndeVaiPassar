using OndeVaiPassar.Domain.Entities.Sports;

namespace OndeVaiPassar.Command.Sports;

public interface ISportCommandStore
{
    Task<int> CreateAsync(SportEntity sport);
    Task<int> UpdateAsync(SportEntity sport);
    Task<int> DeleteAsync(int id);
}
