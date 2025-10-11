namespace OndeVaiPassar.Domain.Entities.Sports;

public class SportEntity : BaseEntity
{
    public required string Name { get; set; }
    public string? LogoUrl { get; set; }
}
