namespace OndeVaiPassar.Domain.Entities.Teams;

public class TeamEntity : BaseEntity
{
    public required string Name { get; set; }
    public required string ShortName { get; set; }
    public required string Abbreviation { get; set; }
    public required string Color { get; set; }
    public int SportId { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
}
