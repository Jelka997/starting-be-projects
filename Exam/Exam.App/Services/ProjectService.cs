using AutoMapper;
using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Exam.App.Services.Dtos;
using Exam.App.Services.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Exam.App.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public ProjectService(IProjectRepository projectRepository, IMapper mapper, UserManager<ApplicationUser> userManager, IUserRepository userRepository)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
        _userManager = userManager;
        _userRepository = userRepository;
    }

    public async Task<ProjectDto> CreateAsync(ProjectDto dto, string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        var project = new Project
        {
            Name = dto.Name,
            Description = dto.Description,
            StartedAt = dto.StartedAt,
            Status = ProjectStatus.Draft,
            UserId = user.Id
        };

        var created = await _projectRepository.CreateAsync(project);
        return _mapper.Map<ProjectDto>(created);
    }

    public async Task<ProjectDto> UpdateAsync(int id, ProjectDto dto, string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        var project = await _projectRepository.GetProjectByUserIdAsync(id, user.Id);
        if (project == null)
            throw new NotFoundException(id);

        if (project.Status == ProjectStatus.Completed)
        {
            project.Name = project.Name;
            project.Description = project.Description;
            project.StartedAt = project.StartedAt;
            project.CompletedAt = dto.CompletedAt;
            project.Status = dto.Status;
        }
        else
        {
            project.Name = dto.Name;
            project.Description = dto.Description;
            project.StartedAt = dto.StartedAt;
            project.CompletedAt = dto.CompletedAt;
            project.Status = dto.Status;
        }
        await _projectRepository.UpdateAsync(project);
        return _mapper.Map<ProjectDto>(project);
    }

    public async Task DeleteAsync(int id, string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        var result = await _projectRepository.GetProjectByUserIdAsync(id, user.Id);
        if (result == null)
        {
            throw new BadRequestException("This project does not belog to this user.");
        }
        await _projectRepository.DeleteAsync(result.Id);
    }
    // prikazati broj kompletiranih projekata, broj projekata u realizaciji i datum najskorije kompletiranog projekta
    public async Task<ProjectUserDto> GetByUserIdAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var projects = await _projectRepository.GetByUserIdAsync(userId);
        var result = projects.Where(p => p.Status == ProjectStatus.Completed || p.Status == ProjectStatus.Published); //promena da ne budu u pripremi i arhivirani projekti
        return new ProjectUserDto
        {
            FullName = user.Name + " " + user.Surname,
            CompletedProjects = result.Count(result => result.Status == ProjectStatus.Completed),
            PublishedProjects = result.Count(result => result.Status == ProjectStatus.Published),
            LatestCompletedProject = result.Where(p => p.Status == ProjectStatus.Completed)
            .Max(p => (DateTime?)p.CompletedAt),
            ListProjects = _mapper.Map<List<ProjectDto>>(result)
        };
    }

    public async Task<List<ProjectDto>> GetOwnedAsync(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        var result = await _projectRepository.GetByUserIdAsync(user.Id);
        return _mapper.Map<List<ProjectDto>>(result);
    }
}
