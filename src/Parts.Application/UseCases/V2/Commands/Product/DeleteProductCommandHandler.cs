using Parts.Contract.Abstractions.Message;
using Parts.Contract.Services.V2.Product;
using Parts.Contract.Shared;
using Parts.Domain.Abstractions.Dappers;
using Parts.Domain.Exceptions;

namespace Parts.Application.UseCases.V2.Commands.Product;
public sealed class DeleteProductCommandHandler : ICommandHandler<Command.DeleteProductCommand>
{
    private readonly IUnitOfWork _unitOfWork; // SQL-SERVER-STRATEGY-2

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(Command.DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id)
            ?? throw new ProductException.ProductNotFoundException(request.Id);

        var result = await _unitOfWork.Products.DeleteAsync(product.Id);

        return Result.Success(result);
    }
}
