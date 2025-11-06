using SharedKernel;

namespace Domain.Entities.Todos;

public sealed class TodoItem : Entity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Description { get; set; }
    public DateTime? DueDate { get; set; }

    private readonly List<string> _labels = [];
    public IReadOnlyList<string> Labels => _labels.AsReadOnly();

    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public Priority Priority { get; set; }
    
    public void AddLabels(IEnumerable<string> labels)
    {
        _labels.AddRange(labels);
    }
}


