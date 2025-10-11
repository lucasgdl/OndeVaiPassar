using Dapper;
using OndeVaiPassar.Domain.Entities.Broadcasters;
using OndeVaiPassar.Domain.Entities.Event;
using OndeVaiPassar.Domain.Entities.EventBroadcasts;
using OndeVaiPassar.Query.Events;
using System.Data;

namespace OndeVaiPassar.QueryStore.Events;

public class EventQueryStore : IEventQueryStore
{
    private readonly IDbConnection _db;

    public EventQueryStore(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<EventEntity>> GetAllAsync()
    {
        var sql = @"
SELECT e.Id, e.Name, e.SportId, e.DateTime, e.OperatorCode, e.CreatedAt,
       eb.Id, eb.EventId, eb.BroadcasterId, eb.OperatorCode AS EB_OperatorCode, eb.CreatedAt AS EB_CreatedAt,
       b.Id, b.Name, b.LogoUrl, b.Link, b.OperatorCode AS B_OperatorCode, b.CreatedAt AS B_CreatedAt
FROM Events e
LEFT JOIN EventBroadcasts eb ON eb.EventId = e.Id
LEFT JOIN Broadcasters b ON b.Id = eb.BroadcasterId
";

        var eventDict = new Dictionary<long, EventEntity>();

        await _db.QueryAsync<EventEntity, EventBroadcastEntity, BroadcasterEntity, EventEntity>(sql,
            map: (e, eb, b) =>
            {
                if (!eventDict.TryGetValue(e.Id, out var existing))
                {
                    existing = e;
                    existing.Broadcasts = new List<EventBroadcastEntity>();
                    eventDict.Add(existing.Id, existing);
                }

                if (eb != null && eb.Id != 0)
                {
                    existing.Broadcasts.Add(eb);
                }

                return existing;
            },
            splitOn: "Id,Id");

        return eventDict.Values;
    }

    public async Task<EventEntity?> GetByIdAsync(long id)
    {
        var sql = @"
SELECT e.Id, e.Name, e.SportId, e.DateTime, e.OperatorCode, e.CreatedAt,
       eb.Id, eb.EventId, eb.BroadcasterId, eb.OperatorCode AS EB_OperatorCode, eb.CreatedAt AS EB_CreatedAt,
       b.Id, b.Name, b.LogoUrl, b.Link, b.OperatorCode AS B_OperatorCode, b.CreatedAt AS B_CreatedAt
FROM Events e
LEFT JOIN EventBroadcasts eb ON eb.EventId = e.Id
LEFT JOIN Broadcasters b ON b.Id = eb.BroadcasterId
WHERE e.Id = @Id
";

        var eventDict = new Dictionary<long, EventEntity>();

        await _db.QueryAsync<EventEntity, EventBroadcastEntity, BroadcasterEntity, EventEntity>(sql,
            map: (e, eb, b) =>
            {
                if (!eventDict.TryGetValue(e.Id, out var existing))
                {
                    existing = e;
                    existing.Broadcasts = new List<EventBroadcastEntity>();
                    eventDict.Add(existing.Id, existing);
                }

                if (eb != null && eb.Id != 0)
                {
                    existing.Broadcasts.Add(eb);
                }

                return existing;
            },
            param: new { Id = id },
            splitOn: "Id,Id");

        return eventDict.Values.FirstOrDefault();
    }
}
