using AutoMapper;
using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Exam.App.Services.Dtos;
using Exam.App.Services.Exceptions;

namespace Exam.App.Services
{
    public class ProjectSkillService : IProjectSkillService
    {
        private readonly IProjectSkillRepository _projectSkillRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ISkillsRepository _skillsRepository;
        private readonly IMapper _mapper;

        public ProjectSkillService(IProjectSkillRepository projectSkillRepository, IProjectRepository projectRepository, ISkillsRepository skillsRepository, IMapper mapper)
        {
            _projectSkillRepository = projectSkillRepository;
            _projectRepository = projectRepository;
            _skillsRepository = skillsRepository;
            _mapper = mapper;
        }

        public async Task<ProjectSkillsDto> AddSkilToProject(ProjectSkillsDto projectSkillsDto)
        {
            var project = _projectRepository.GetByIdAsync(projectSkillsDto.ProjectId);
            if (project == null)
            {
                throw new NotFoundException(projectSkillsDto.ProjectId);
            }
            var skill = _skillsRepository.GetSkillById(projectSkillsDto.SkillId);
            if (skill == null)
            {
                throw new NotFoundException(projectSkillsDto.SkillId);
            }

            var result = _mapper.Map<ProjectSkill>(projectSkillsDto);
            await _projectSkillRepository.AddSkilToProject(result);
            return projectSkillsDto;
        }
    }
}
