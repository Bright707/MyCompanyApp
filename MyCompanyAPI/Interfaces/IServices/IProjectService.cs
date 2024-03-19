using MyCompanyAPI.DTOs;

namespace MyCompanyAPI.Interfaces.IServices
{
    public interface IProjectService
    {
        Task<ProjectDTO> GetProjectByIdAsync(int projectId);
        Task<IEnumerable<ProjectDTO>> GetAllProjectAsync();
        Task<bool> AddProjectAsync(ProjectDTO projectDTO);
        Task UpdateProjectAsync(int projectId, ProjectDTO projectDTO);
        Task DeleteProjectAsync(int projectId);
    }
}
