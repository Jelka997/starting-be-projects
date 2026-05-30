using Exam.App.Domain;

namespace Exam.App.Services.Dtos
{
    public class ProjectUserDto
    {
        public string FullName { get; set; }
        public int? CompletedProjects { get; set; }
        public int? PublishedProjects { get; set; }
        public DateTime? LatestCompletedProject { get; set; }
        public List<ProjectDto>? ListProjects { get; set; } = [];
    }
}
