using System.Data;
using OndeVaiPassar.Command.Sports;
using OndeVaiPassar.Domain.Entities.Sports;
using Dapper;

namespace OndeVaiPassar.CommandStore.Sports;

public class SportCommandStore : ISportCommandStore
{
    private readonly IDbConnection _db;

    public SportCommandStore(IDbConnection db)
    {
        _db = db;
    }

    public async Task<int> AddAsync(SportEntity item)
    {
        var sql = "INSERT INTO Sports (Name, LogoUrl, OperatorCode, CreatedAt) VALUES (@Name, @LogoUrl, @OperatorCode, @CreatedAt); SELECT CAST(SCOPE_IDENTITY() as int);";
        return await _db.ExecuteScalarAsync<int>(sql, item);
    }

    public async Task<int> UpdateAsync(SportEntity item)
    {
        var sql = "UPDATE Sports SET Name = @Name, LogoUrl = @LogoUrl WHERE Id = @Id";
        return await _db.ExecuteAsync(sql, item);
    }
}
