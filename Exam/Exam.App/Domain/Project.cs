using static Exam.App.Domain.ProjectSkill;

namespace Exam.App.Domain;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public ProjectStatus Status { get; set; }
    public string UserId { get; set; }
    public List<ProjectSkill> ProjectSkills { get; set; } = new();

}
