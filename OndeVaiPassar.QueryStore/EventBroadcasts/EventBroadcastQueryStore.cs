using Dapper;
using OndeVaiPassar.Domain.Entities.EventBroadcasts;
using OndeVaiPassar.Query.EventBroadcasts;
using System.Data;

namespace OndeVaiPassar.QueryStore.EventBroadcasts;

public class EventBroadcastQueryStore : IEventBroadcastQueryStore
{
    private readonly IDbConnection _db;

    public EventBroadcastQueryStore(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<EventBroadcastEntity>> GetAllAsync()
    {
        var sql = "SELECT Id, EventId, BroadcasterId, OperatorCode, CreatedAt FROM EventBroadcasts";
        return await _db.QueryAsync<EventBroadcastEntity>(sql);
    }

    public async Task<EventBroadcastEntity?> GetByIdAsync(long id)
    {
        var sql = "SELECT Id, EventId, BroadcasterId, OperatorCode, CreatedAt FROM EventBroadcasts WHERE Id = @Id";
        return await _db.QueryFirstOrDefaultAsync<EventBroadcastEntity>(sql, new { Id = id });
    }
}
