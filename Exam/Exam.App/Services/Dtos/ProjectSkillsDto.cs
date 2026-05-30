using Exam.App.Domain;

namespace Exam.App.Services.Dtos
{
    public class ProjectSkillsDto
    {
        public int ProjectId { get; set; }
        public int SkillId { get; set; }
        public string Description { get; set; }
    }
}
