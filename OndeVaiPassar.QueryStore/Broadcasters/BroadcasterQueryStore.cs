using Dapper;
using OndeVaiPassar.Domain.Entities.Broadcasters;
using OndeVaiPassar.Query.Broadcasters;
using System.Data;

namespace OndeVaiPassar.QueryStore.Broadcasters;

public class BroadcasterQueryStore : IBroadcasterQueryStore
{
    private readonly IDbConnection _db;

    public BroadcasterQueryStore(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<BroadcasterEntity>> GetAllAsync()
    {
        var sql = "SELECT Id, Name, LogoUrl, Link, OperatorCode, CreatedAt FROM Broadcasters";
        return await _db.QueryAsync<BroadcasterEntity>(sql);
    }

    public async Task<BroadcasterEntity?> GetByIdAsync(long id)
    {
        var sql = "SELECT Id, Name, LogoUrl, Link, OperatorCode, CreatedAt FROM Broadcasters WHERE Id = @Id";
        return await _db.QueryFirstOrDefaultAsync<BroadcasterEntity>(sql, new { Id = id });
    }
}
