namespace Domain.Entities;

using Domain.Common;
using Domain.Enums;

public class Bug : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string  Url { get; set; } = string.Empty;
    public int RewardTokens { get; set; }
    public BugStatus Status { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public Guid CreatedBy { get; set; }
    public GlobalUser? Assigned { get; set; }
    public int GlobalUserId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Completed { get; set;}
}
