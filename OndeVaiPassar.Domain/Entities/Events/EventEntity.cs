using OndeVaiPassar.Domain.Entities.EventBroadcasts;

namespace OndeVaiPassar.Domain.Entities.Event;

public class EventEntity : BaseEntity
{
    public required string Name { get; set; }
    public long SportId { get; set; }
    public long TournamentId { get; set; }
    public DateTime DateTime { get; set; }
    public List<EventBroadcastEntity> Broadcasts { get; set; } = [];
}
