namespace OndeVaiPassar.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string OperatorCode { get; set; }

    public void SetId(int id)
    {
        Id = id;
    }
}
