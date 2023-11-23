using Domain.Common;

namespace Domain.Entities;

public class Comment : BaseEntity
{
    public string Text { get; set; } = string.Empty;
    public GlobalUser Author { get; set; } = new();
    public DateTime Created { get; set; }
    public DateTime? Edited { get; set; }
}
