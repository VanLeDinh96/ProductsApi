using AutoMapper;
using Parts.Contract.Abstractions.Message;
using Parts.Contract.Services.V2.Product;
using Parts.Contract.Shared;
using Parts.Domain.Abstractions.Dappers;

namespace Parts.Application.UseCases.V2.Queries;
public sealed class GetProductsQueryHandler : IQueryHandler<Query.GetProductsQuery, Result<List<Response.ProductResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Result<List<Response.ProductResponse>>>> Handle(Query.GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Products.GetAllAsync();

        var results = _mapper.Map<List<Response.ProductResponse>>(products);

        return Result.Success(results);
    }
}
