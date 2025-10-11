namespace OndeVaiPassar.Domain.Entities.EventBroadcasts;

public class EventBroadcastEntity : BaseEntity
{
    public long EventId { get; set; }
    public long BroadcasterId { get; set; }
}
