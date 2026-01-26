using FastEndpoints;
using Microsoft.Extensions.Logging;
using no.sanddata.ams.Application.Abstractions.Messaging;

namespace no.sanddata.ams.Application.Abstractions.Processor;

public partial class LoggingPostProcessor<TRequest,TResponse> : IPostProcessor<TRequest,TResponse> where TRequest : IBaseCommand
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
        LogExecutedCommandCommand(name);
        
        return Task.CompletedTask;
    }

    [LoggerMessage(LogLevel.Information, "Executed command {Command}")]
    partial void LogExecutedCommandCommand(string Command);
}
