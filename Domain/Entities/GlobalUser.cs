using Domain.Common;
namespace Domain.Entities;

public class GlobalUser : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid GlobalIdentity { get; set; }
    public ICollection<Bug>? AssignedBugs { get; set; }
}