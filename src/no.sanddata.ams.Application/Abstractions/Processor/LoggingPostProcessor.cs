using FastEndpoints;
using Microsoft.Extensions.Logging;
using no.sanddata.ams.Application.Abstractions.Messaging;

namespace no.sanddata.ams.Application.Abstractions.Processor;

public class LoggingPostProcessor<TRequest,TResponse> : IPostProcessor<TRequest,TResponse> where TRequest : IBaseCommand
{
    private readonly ILogger<LoggingPostProcessor<TRequest,TResponse>> _logger;

    public LoggingPostProcessor(ILogger<LoggingPostProcessor<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public Task PostProcessAsync(IPostProcessorContext<TRequest, TResponse>? context, CancellationToken ct)
    {
        if (context == null)
        {
            return Task.CompletedTask;
        }

        string name = context.GetType().Name;
        _logger.LogInformation("Executed command {Command}", name);
        
        return Task.CompletedTask;
    }
}
