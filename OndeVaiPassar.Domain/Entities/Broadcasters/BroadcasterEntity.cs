namespace OndeVaiPassar.Domain.Entities.Broadcasters;

public class BroadcasterEntity : BaseEntity
{
    public required string Name { get; set; }
    public required string ShortName { get; set; }
    public required string Color { get; set; }
    public string? Link { get; set; }
}
