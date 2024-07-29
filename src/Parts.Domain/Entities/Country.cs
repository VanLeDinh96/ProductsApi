using Parts.Domain.Abstractions.Entities;

namespace Parts.Domain.Entities;
public class Country : Entity<Guid>, IAuditableEntity
{
    public string Name { get; set; }
    public DateTimeOffset CreatedOnUtc { get; set; }
    public DateTimeOffset? ModifiedOnUtc { get; set; }
    public virtual ICollection<Supplier> Suppliers { get; set; }
}
