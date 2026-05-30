using Exam.App.Services.Dtos;

namespace Exam.App.Services
{
    public interface IProjectSkillService
    {
        Task<ProjectSkillsDto> AddSkilToProject(ProjectSkillsDto projectSkillsDto);
    }
}