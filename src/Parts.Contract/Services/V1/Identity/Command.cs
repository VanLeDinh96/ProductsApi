using Parts.Contract.Abstractions.Message;

namespace Parts.Contract.Services.V1.Identity;
public static class Command
{
    public record Revoke(string AccessToken) : ICommand;
}
