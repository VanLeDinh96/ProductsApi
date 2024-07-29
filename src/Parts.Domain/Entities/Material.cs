using Parts.Domain.Abstractions.Entities;

namespace Parts.Domain.Entities;
public class Material : Entity<Guid>, IAuditableEntity
{
    public string Name { get; set; }
    public DateTimeOffset CreatedOnUtc { get; set; }
    public DateTimeOffset? ModifiedOnUtc { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
