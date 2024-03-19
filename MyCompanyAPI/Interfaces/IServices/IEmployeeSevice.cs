using MyCompanyAPI.DTOs;

namespace MyCompanyAPI.Interfaces.IServices
{
    // Services/IEmployeeService.cs
    // Services/IEmployeeService.cs
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetEmployeeByIdAsync(int employeeId);
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
        Task<bool> AddEmployeeAsync(EmployeeDTO employeeDTO);
        Task UpdateEmployeeAsync(int employeeId, EmployeeDTO employeeDTO);
        Task DeleteEmployeeAsync(int employeeId);
    }
}
