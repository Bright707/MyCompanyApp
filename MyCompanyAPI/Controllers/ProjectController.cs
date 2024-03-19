using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompanyAPI.DTOs;
using MyCompanyAPI.Interfaces.IServices;

namespace MyCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(IProjectService projectService, ILogger<ProjectController> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetProjectById(int projectId)
        {
            try
            {
                var project = await _projectService.GetProjectByIdAsync(projectId);

                if (project == null)
                    return NotFound($"Project with ID {projectId} not found.");

                return Ok(project);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting employee with ID {projectId}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProject()
        {
            try
            {
                var projects = await _projectService.GetAllProjectAsync();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting all project: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] ProjectDTO projectDTO)
        {
            try
            {
                if (projectDTO == null)
                    return BadRequest("Invalid project data");

                await _projectService.AddProjectAsync(projectDTO);
                return Ok("Project added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding project: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(int projectId, [FromBody] ProjectDTO projectDTO)
        {
            try
            {
                await _projectService.UpdateProjectAsync(projectId, projectDTO);
                return Ok("Project updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating project with ID {projectId}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            try
            {
                await _projectService.DeleteProjectAsync(projectId);
                return Ok("Project deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting employee with ID {projectId}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

