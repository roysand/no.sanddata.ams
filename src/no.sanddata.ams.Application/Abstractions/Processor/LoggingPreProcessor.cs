using FastEndpoints;
using Microsoft.Extensions.Logging;
using no.sanddata.ams.Application.Abstractions.Messaging;

namespace no.sanddata.ams.Application.Abstractions.Processor;

public partial class LoggingPreProcessor<TRequest> : IPreProcessor<TRequest> where TRequest : IBaseCommand
{
    private readonly ILogger<LoggingPreProcessor<TRequest>> _logger;

    public LoggingPreProcessor(ILogger<LoggingPreProcessor<TRequest>> logger)
    {
        _logger = logger;
    }

    public Task PreProcessAsync(IPreProcessorContext<TRequest>? context, CancellationToken ct)
    {
        if (context == null)
        {
            return Task.CompletedTask;
        }

        string name = context.GetType().Name;
        LogExecutingCommand(_logger, name);

        return Task.CompletedTask;
   }
    
        
    [LoggerMessage(Level = LogLevel.Information, Message = "Executing command {Command}")]
    private static partial void LogExecutingCommand(ILogger logger, string command);
}
