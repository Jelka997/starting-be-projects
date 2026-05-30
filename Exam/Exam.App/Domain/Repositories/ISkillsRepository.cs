using Exam.App.Domain;

namespace Exam.App.Domain.Repositories
{
    public interface ISkillsRepository
    {
        Task<List<Skill>> GetAllSkills();
        Task<Skill?> GetSkillById(int id);
    }
}