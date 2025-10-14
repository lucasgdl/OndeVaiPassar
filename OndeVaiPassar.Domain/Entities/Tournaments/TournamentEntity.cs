namespace OndeVaiPassar.Domain.Entities.Tournaments;

public class TournamentEntity : BaseEntity
{
    public required string Name { get; set; }
    public required string SportId { get; set; }
}
