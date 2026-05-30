using Exam.App.Domain;
using Exam.App.Domain.Repositories;

namespace Exam.App.Infrastructure.Database.Repositories
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly AppDbContext _context;

        public SkillsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            return _context.Skills.ToList();
        }

        public async Task<Skill?> GetSkillById(int id)
        {
            return await _context.Skills.FindAsync(id);
        }
    }
}
