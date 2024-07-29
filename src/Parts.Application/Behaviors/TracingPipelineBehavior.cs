using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Parts.Application.Behaviors;
public class TracingPipelineBehavior<TRequest, TResponse>(ILogger<TRequest> logger) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch _timer = new Stopwatch();
    private readonly ILogger<TRequest> _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();
        TResponse? response = await next();
        _timer.Stop();

        long elapsedMilliseconds = _timer.ElapsedMilliseconds;
        string requestName = typeof(TRequest).Name;
        _logger.LogInformation("Request Details: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}", requestName, elapsedMilliseconds, request);

        return response;
    }
}
