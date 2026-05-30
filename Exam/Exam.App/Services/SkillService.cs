using AutoMapper;
using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Exam.App.Services.Dtos;

namespace Exam.App.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillsRepository _skillsRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillsRepository skillsRepository, IMapper mapper)
        {
            _skillsRepository = skillsRepository;
            _mapper = mapper;
        }

        public async Task<List<SkillDto>> GetAllSkills()
        {
            var result = await _skillsRepository.GetAllSkills();
            return _mapper.Map<List<SkillDto>>(result);
        }
    }
}
