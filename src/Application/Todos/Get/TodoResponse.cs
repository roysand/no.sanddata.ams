namespace Application.Todos.Get;

public sealed class TodoResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public IReadOnlyList<string> Labels { get; init; } = [];
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
