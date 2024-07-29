using Parts.Contract.Abstractions.Message;
using Parts.Contract.Services.V2.Product;
using Parts.Contract.Shared;
using Parts.Domain.Abstractions.Dappers;
using Parts.Domain.Exceptions;

namespace Parts.Application.UseCases.V2.Commands.Product;
public sealed class UpdateProductCommandHandler : ICommandHandler<Command.UpdateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(Command.UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id)
            ?? throw new ProductException.ProductNotFoundException(request.Id);

        product.Update(request.Name, request.Price, request.Description);

        var result = await _unitOfWork.Products.UpdateAsync(product);

        return Result.Success(result);
    }
}
