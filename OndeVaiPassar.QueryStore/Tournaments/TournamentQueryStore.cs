using System.Data;
using Dapper;
using OndeVaiPassar.Domain.Entities.Tournaments;
using OndeVaiPassar.Query.Tournaments;

namespace OndeVaiPassar.QueryStore.Tournaments;

public class TournamentQueryStore : ITournamentQueryStore
{
    private readonly IDbConnection _db;

    public TournamentQueryStore(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<TournamentEntity>> GetAllAsync()
    {
        var sql = "SELECT Id, Name, LogoUrl, OperatorCode, CreatedAt FROM Tournaments";
        return await _db.QueryAsync<TournamentEntity>(sql);
    }

    public async Task<TournamentEntity?> GetByIdAsync(long id)
    {
        var sql = "SELECT Id, Name, LogoUrl, OperatorCode, CreatedAt FROM Tournaments WHERE Id = @Id";
        return await _db.QueryFirstOrDefaultAsync<TournamentEntity>(sql, new { Id = id });
    }
}
