using Parts.Contract.Abstractions.Message;
using Parts.Contract.Enumerations;
using Parts.Contract.Shared;
using static Parts.Contract.Services.V1.Product.Response;

namespace Parts.Contract.Services.V1.Product;
public static class Query
{
    public record GetProductsQuery(string? SearchTerm, string? SortColumn, SortOrder? SortOrder, IDictionary<string, SortOrder>? SortColumnAndOrder, int PageIndex, int PageSize) : IQuery<PagedResult<ProductResponse>>;
    public record GetProductByIdQuery(Guid Id) : IQuery<ProductResponse>;
}
