using MediatR;

namespace Parts.Contract.Abstractions.Message;

public interface IDomainEvent : INotification
{
    public Guid IdEvent { get; init; }
}
