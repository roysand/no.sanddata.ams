using Application.Abstractions.Messaging;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using SharedKernel;

namespace Application.Abstractions.Behaviors;

internal static class LoggingDecorator
{
    internal sealed class CommandHandler<TCommand, TResponse>(
        ICommandHandler<TCommand, TResponse> innerHandler,
        ILogger<CommandHandler<TCommand, TResponse>> logger)
        : ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand
    {
        private static readonly Action<ILogger, string, Exception?> _processingCommand = LoggerMessage.Define<string>(LogLevel.Information, new EventId(1, "ProcessingCommand"), "Processing command {Command}");
        private static readonly Action<ILogger, string, Exception?> _completedCommand = LoggerMessage.Define<string>(LogLevel.Information, new EventId(2, "CompletedCommand"), "Completed command {Command}");
        private static readonly Action<ILogger, string, Exception?> _completedCommandWithError = LoggerMessage.Define<string>(LogLevel.Error, new EventId(3, "CompletedCommandWithError"), "Completed command {Command} with error");

        public async Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken)
        {
            string commandName = typeof(TCommand).Name;

            _processingCommand(logger, commandName, null);

            Result<TResponse> result = await innerHandler.Handle(command, cancellationToken).ConfigureAwait(false);

            if (result.IsSuccess)
            {
                _completedCommand(logger, commandName, null);
            }
            else
            {
                using (LogContext.PushProperty("Error", result.Error, true))
                {
                    _completedCommandWithError(logger, commandName, null);
                }
            }

            return result;
        }
    }

    internal sealed class CommandBaseHandler<TCommand>(
        ICommandHandler<TCommand> innerHandler,
        ILogger<CommandBaseHandler<TCommand>> logger)
        : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private static readonly Action<ILogger, string, Exception?> _processingCommand = LoggerMessage.Define<string>(LogLevel.Information, new EventId(4, "ProcessingCommandBase"), "Processing command {Command}");
        private static readonly Action<ILogger, string, Exception?> _completedCommand = LoggerMessage.Define<string>(LogLevel.Information, new EventId(5, "CompletedCommandBase"), "Completed command {Command}");
        private static readonly Action<ILogger, string, Exception?> _completedCommandWithError = LoggerMessage.Define<string>(LogLevel.Error, new EventId(6, "CompletedCommandBaseWithError"), "Completed command {Command} with error");

        public async Task<Result> Handle(TCommand command, CancellationToken cancellationToken)
        {
            string commandName = typeof(TCommand).Name;

            _processingCommand(logger, commandName, null);

            Result result = await innerHandler.Handle(command, cancellationToken).ConfigureAwait(false);

            if (result.IsSuccess)
            {
                _completedCommand(logger, commandName, null);
            }
            else
            {
                using (LogContext.PushProperty("Error", result.Error, true))
                {
                    _completedCommandWithError(logger, commandName, null);
                }
            }

            return result;
        }
    }

    internal sealed class QueryHandler<TQuery, TResponse>(
        IQueryHandler<TQuery, TResponse> innerHandler,
        ILogger<QueryHandler<TQuery, TResponse>> logger)
        : IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery
    {
        private static readonly Action<ILogger, string, Exception?> _processingQuery = LoggerMessage.Define<string>(LogLevel.Information, new EventId(7, "ProcessingQuery"), "Processing query {Query}");
        private static readonly Action<ILogger, string, Exception?> _completedQuery = LoggerMessage.Define<string>(LogLevel.Information, new EventId(8, "CompletedQuery"), "Completed query {Query}");
        private static readonly Action<ILogger, string, Exception?> _completedQueryWithError = LoggerMessage.Define<string>(LogLevel.Error, new EventId(9, "CompletedQueryWithError"), "Completed query {Query} with error");

        public async Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken)
        {
            string queryName = typeof(TQuery).Name;

            _processingQuery(logger, queryName, null);

            Result<TResponse> result = await innerHandler.Handle(query, cancellationToken).ConfigureAwait(false);

            if (result.IsSuccess)
            {
                _completedQuery(logger, queryName, null);
            }
            else
            {
                using (LogContext.PushProperty("Error", result.Error, true))
                {
                    _completedQueryWithError(logger, queryName, null);
                }
            }

            return result;
        }
    }
}
