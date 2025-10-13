namespace OndeVaiPassar.Domain.Entities.Sports;

public sealed class SportEntity : BaseEntity
{
    public string Name { get; private set; }
    public string? LogoUrl { get; private set; }

    public SportEntity(string name, string? logoUrl)
    {
        Name = name;
        LogoUrl = logoUrl;
        CreatedAt = DateTime.UtcNow;
        OperatorCode = "system"; // Default value, should be set appropriately
    }

    public static SportEntity Create(string name, string logoUrl)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required", nameof(name));

        return new SportEntity(name, logoUrl);
    }

    public void Update(string name, string logoUrl)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required", nameof(name));

        Name = name.Trim();
        LogoUrl = logoUrl;
        UpdatedAt = DateTime.UtcNow;
    }
}
