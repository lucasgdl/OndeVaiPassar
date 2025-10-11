namespace OndeVaiPassar.Domain.Entities;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string OperatorCode { get; set; }
}
