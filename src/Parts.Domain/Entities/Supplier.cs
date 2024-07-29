using Parts.Domain.Abstractions.Entities;

namespace Parts.Domain.Entities;
public class Supplier : Entity<Guid>, IAuditableEntity
{
    public string Name { get; set; }
    public Guid? CountryId { get; set; }
    public DateTimeOffset CreatedOnUtc { get; set; }
    public DateTimeOffset? ModifiedOnUtc { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
