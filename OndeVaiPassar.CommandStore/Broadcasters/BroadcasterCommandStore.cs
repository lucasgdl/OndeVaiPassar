using System.Data;
using Dapper;
using OndeVaiPassar.Command.Broadcasters;
using OndeVaiPassar.Domain.Entities.Broadcasters;

namespace OndeVaiPassar.CommandStore.Broadcasters;

public class BroadcasterCommandStore : IBroadcasterCommandStore
{
    private readonly IDbConnection _db;

    public BroadcasterCommandStore(IDbConnection db)
    {
        _db = db;
    }

    public async Task<int> AddAsync(BroadcasterEntity item)
    {
        var sql = "INSERT INTO Broadcasters (Name, LogoUrl, Link, OperatorCode, CreatedAt) VALUES (@Name, @LogoUrl, @Link, @OperatorCode, @CreatedAt); SELECT CAST(SCOPE_IDENTITY() as int);";
        return await _db.ExecuteScalarAsync<int>(sql, item);
    }

    public async Task<int> UpdateAsync(BroadcasterEntity item)
    {
        var sql = "UPDATE Broadcasters SET Name = @Name, LogoUrl = @LogoUrl, Link = @Link WHERE Id = @Id";
        return await _db.ExecuteAsync(sql, item);
    }
}
