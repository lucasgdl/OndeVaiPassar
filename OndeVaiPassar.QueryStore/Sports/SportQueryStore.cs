using System.Data;
using OndeVaiPassar.Domain.Entities.Sports;
using OndeVaiPassar.Query.Sports;
using Dapper;

namespace OndeVaiPassar.QueryStore.Sports;

public class SportQueryStore : ISportQueryStore
{
    private readonly IDbConnection _db;

    public SportQueryStore(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<SportEntity>> GetAllAsync()
    {
        var sql = "SELECT Id, Name, LogoUrl, OperatorCode, CreatedAt FROM Sports";
        return await _db.QueryAsync<SportEntity>(sql);
    }

    public async Task<SportEntity?> GetByIdAsync(long id)
    {
        var sql = "SELECT Id, Name, LogoUrl, OperatorCode, CreatedAt FROM Sports WHERE Id = @Id";
        return await _db.QueryFirstOrDefaultAsync<SportEntity>(sql, new { Id = id });
    }
}
