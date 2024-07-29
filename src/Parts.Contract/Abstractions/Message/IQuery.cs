using MediatR;
using Parts.Contract.Shared;

namespace Parts.Contract.Abstractions.Message;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{ }
