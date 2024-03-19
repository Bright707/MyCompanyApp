using Microsoft.AspNetCore.Mvc;
using MyCompanyAPI.DTOs;
using MyCompanyAPI.Interfaces.IServices;

namespace MyCompanyAPI.Controllers
{
    // Controllers/EmployeeController.cs
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int employeeId)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);

                if (employee == null)
                    return NotFound($"Employee with ID {employeeId} not found.");

                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting employee with ID {employeeId}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting all employees: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                if (employeeDTO == null)
                    return BadRequest("Invalid employee data");

                await _employeeService.AddEmployeeAsync(employeeDTO);
                return Ok("Employee added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding employee: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                await _employeeService.UpdateEmployeeAsync(employeeId, employeeDTO);
                return Ok("Employee updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating employee with ID {employeeId}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(employeeId);
                return Ok("Employee deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting employee with ID {employeeId}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
