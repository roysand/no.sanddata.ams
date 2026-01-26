using FastEndpoints;
using FluentValidation.Results;
using no.sanddata.ams.Api.Extensions;
using no.sanddata.ams.Api.Infrastructure;
using no.sanddata.ams.Application.Abstractions.Messaging;
using no.sanddata.ams.Application.Users.GetAllUsers;
using no.sanddata.ams.Domain.Abstractions;
using YamlDotNet.Serialization.Schemas;

namespace no.sanddata.ams.Api.Features.Users.GetAllUsers;

internal sealed class GetAllUsers : Endpoint<GetAllUsersQuery, Result<IReadOnlyList<GetAllUsersResponse>>>
{
    private readonly IQueryHandler<GetAllUsersQuery, IReadOnlyList<GetAllUsersResponse>> _handler;

    public GetAllUsers(IQueryHandler<GetAllUsersQuery, IReadOnlyList<GetAllUsersResponse>> handler)
    {
        _handler = handler;
    }
    public override void Configure()
    {
        Get("/users");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Get all users";
            s.Description = "Retrieves a list of all users in the system.";
            s.Responses[200] = "A list of users.";
        });
    }

    public override async Task<Result> HandleAsync(GetAllUsersQuery req, CancellationToken ct)
    {
        Result<IReadOnlyList<GetAllUsersResponse>> result = await _handler.HandleAsync(req, ct);
        return result;
    }
}
