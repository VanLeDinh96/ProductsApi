using Parts.Domain.Abstractions.Dappers.Repositories.Product;

namespace Parts.Domain.Abstractions.Dappers;
public interface IUnitOfWork
{
    IProductRepository Products { get; }
}
