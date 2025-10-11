using System.Data;
using Dapper;
using OndeVaiPassar.Command.Events;
using OndeVaiPassar.Domain.Entities.Event;

namespace OndeVaiPassar.CommandStore.Events;

public class EventCommandStore : IEventCommandStore
{
    private readonly IDbConnection _db;

    public EventCommandStore(IDbConnection db)
    {
        _db = db;
    }

    public async Task<int> AddAsync(EventEntity item)
    {
        var sql = "INSERT INTO Events (Name, SportId, TournamentId, DateTime, OperatorCode, CreatedAt) VALUES (@Name, @SportId, @TournamentId, @DateTime, @OperatorCode, @CreatedAt); SELECT CAST(SCOPE_IDENTITY() as int);";
        return await _db.ExecuteScalarAsync<int>(sql, item);
    }

    public async Task<int> UpdateAsync(EventEntity item)
    {
        var sql = "UPDATE Events SET Name = @Name, SportId = @SportId, TournamentId = @TournamentId, DateTime = @DateTime WHERE Id = @Id";
        return await _db.ExecuteAsync(sql, item);
    }
}
