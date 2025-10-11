using System.Data;
using Dapper;
using OndeVaiPassar.Command.Tournaments;
using OndeVaiPassar.Domain.Entities.Tournaments;

namespace OndeVaiPassar.CommandStore.Tournaments;

public class TournamentCommandStore : ITournamentCommandStore
{
    private readonly IDbConnection _db;

    public TournamentCommandStore(IDbConnection db)
    {
        _db = db;
    }

    public async Task<int> AddAsync(TournamentEntity item)
    {
        var sql = "INSERT INTO Tournaments (Name, LogoUrl, OperatorCode, CreatedAt) VALUES (@Name, @LogoUrl, @OperatorCode, @CreatedAt); SELECT CAST(SCOPE_IDENTITY() as int);";
        return await _db.ExecuteScalarAsync<int>(sql, item);
    }

    public async Task<int> UpdateAsync(TournamentEntity item)
    {
        var sql = "UPDATE Tournaments SET Name = @Name, LogoUrl = @LogoUrl WHERE Id = @Id";
        return await _db.ExecuteAsync(sql, item);
    }
}
