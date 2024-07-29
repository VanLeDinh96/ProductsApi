using Parts.Contract.Abstractions.Message;
using Parts.Contract.Shared;
using static Parts.Contract.Services.V2.Product.Response;

namespace Parts.Contract.Services.V2.Product;
public static class Query
{
    public record GetProductsQuery() : IQuery<Result<List<ProductResponse>>>;
    public record GetProductByIdQuery(Guid Id) : IQuery<ProductResponse>;
}
