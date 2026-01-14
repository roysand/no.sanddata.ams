using no.sanddata.ams.Domain.Abstractions;

namespace no.sanddata.ams.Application.Abstractions.Messaging;

public interface ICommand : IBaseCommand
{
}

#pragma warning disable S2326

public interface ICommand<TResponse> : IBaseCommand
{
}

#pragma warning restore S2326

public interface IBaseCommand
{
    
}
