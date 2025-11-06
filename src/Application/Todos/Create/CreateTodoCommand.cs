using Application.Abstractions.Messaging;
using Domain.Entities.Todos;
using Domain.Todos;

namespace Application.Todos.Create;

public sealed class CreateTodoCommand : ICommand
{
    public Guid UserId { get; set; }
    public required string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public IReadOnlyList<string> Labels { get; init; } = [];
    public Priority Priority { get; set; }
}
