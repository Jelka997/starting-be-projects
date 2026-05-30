using Exam.App.Domain;
using Exam.App.Domain.Repositories;

namespace Exam.App.Infrastructure.Database.Repositories
{
    public class ProjectSkillRepository : IProjectSkillRepository
    {
        private readonly AppDbContext _context;

        public ProjectSkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectSkill> AddSkilToProject(ProjectSkill projectSkills)
        {
            _context.ProjectSkills.Add(projectSkills);
            await _context.SaveChangesAsync();
            return projectSkills;
        }
    }
}
