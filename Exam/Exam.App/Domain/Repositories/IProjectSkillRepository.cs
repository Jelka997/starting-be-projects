using Exam.App.Domain;

namespace Exam.App.Domain.Repositories
{
    public interface IProjectSkillRepository
    {
        Task<ProjectSkill> AddSkilToProject(ProjectSkill projectSkills);
    }
}