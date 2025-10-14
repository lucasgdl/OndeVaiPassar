namespace OndeVaiPassar.Domain.Entities.Venues;

public class VenueEntity : BaseEntity
{
    public required string Name { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required string Image { get; set; }
    public int[]? OwnerTeams { get; set; }
    public string? Address { get; set; }
    public int? Capacity { get; set; }

    public static VenueEntity Create(string name, string image, string city, string state, string country, int[]? ownerTeams, string? address = null, int? capacity = null)
    {
        return new VenueEntity
        {
            Name = name,
            Image = image,
            City = city,
            State = state,
            Country = country,
            OwnerTeams = ownerTeams,
            Address = address,
            Capacity = capacity
        };
    }
    public void Update(string name, string image, string city, string state, string country, int[]? ownerTeams, string? address = null, int? capacity = null)
    {
        Name = name;
        Image = image;
        City = city;
        State = state;
        Country = country;
        OwnerTeams = ownerTeams;
        Address = address;
        Capacity = capacity;
    }
}
