using AutoMapper;
using MyCompanyAPI.DTOs;
using MyCompanyAPI.Interfaces.IRepository;
using MyCompanyAPI.Interfaces.IServices;
using MyCompanyAPI.Models;

namespace MyCompanyAPI.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IBaseRepository<Project> _projectRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(IBaseRepository<Project> projectRepository, IMapper mapper, ILogger<ProjectService> logger)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int projectId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);

            if (project == null)
            {
                _logger.LogWarning($"Project with ID {projectId} not found.");
                return null;
            }

            return _mapper.Map<ProjectDTO>(project);
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjectAsync()
        {
            var projects = await _projectRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectDTO>>(projects);
        }

        public async Task<bool> AddProjectAsync(ProjectDTO projectDTO)
        {

            var project = _mapper.Map<Project>(projectDTO);

            if (project == null)
            {
                return false;
            }
            var Project = new Project
            {
                Name = projectDTO.Name,
                LastName = projectDTO.LastName,
                Description = projectDTO.Description,
                StartDate = projectDTO.StartDate,
                EndDate = projectDTO.EndDate
            };

            await _projectRepository.AddAsync(project);
            return true;
        }

        public async Task UpdateProjectAsync(int projectId, ProjectDTO  projectDTO)
        {
            var existingProject = await _projectRepository.GetByIdAsync(projectId);

            if (existingProject == null)
            {
                _logger.LogWarning($"Project with ID {projectId} not found.");
                return;
            }


            _mapper.Map(projectDTO, existingProject);
            await _projectRepository.UpdateAsync(existingProject);
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);

            if (project == null)
            {
                _logger.LogWarning($"Project with ID {projectId} not found.");
                return;
            }

            await _projectRepository.DeleteAsync(project);
        }
    }
}
