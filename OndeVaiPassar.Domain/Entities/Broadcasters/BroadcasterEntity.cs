namespace OndeVaiPassar.Domain.Entities.Broadcasters;

public class BroadcasterEntity : BaseEntity
{
    public required string Name { get; set; }
    public required string LogoUrl { get; set; }
    public string? Link { get; set; }
}
