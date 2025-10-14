using OndeVaiPassar.Domain.Entities.EventBroadcasts;

namespace OndeVaiPassar.Domain.Entities.Events;

public class EventEntity : BaseEntity
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Round { get; set; } = string.Empty;
    public long SportId { get; set; }
    public long TournamentId { get; set; }
    public long HomeTeamId { get; set; }
    public long AwayTeamId { get; set; }
    public long VenueId { get; set; }
    public DateTime DateTime { get; set; }
    public List<EventBroadcastEntity> Broadcasts { get; set; } = [];
}
