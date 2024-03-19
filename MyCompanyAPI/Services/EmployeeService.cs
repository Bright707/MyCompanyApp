using AutoMapper;
using MyCompanyAPI.DTOs;
using MyCompanyAPI.Interfaces.IRepository;
using MyCompanyAPI.Interfaces.IServices;
using MyCompanyAPI.Models;
using MyCompanyAPI.Repositories;

namespace MyCompanyAPI.Services
{
    // Services/EmployeeService.cs
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IBaseRepository<Employee> employeeRepository, IMapper mapper, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);

            if (employee == null)
            {
                _logger.LogWarning($"Employee with ID {employeeId} not found.");
                return null;
            }

            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public async Task<bool> AddEmployeeAsync(EmployeeDTO employeeDTO)
        {
            
            var employee = _mapper.Map<Employee>(employeeDTO);

            if (employee == null)
            {
                return false;
            }
            var Employee = new Employee
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                PhoneNumber = employeeDTO.PhoneNumber,
                Address = employeeDTO.Address,
                Email = employeeDTO.Email,
                Position = employeeDTO.Position
            };

            await _employeeRepository.AddAsync(employee);
            return true;
        }

        public async Task UpdateEmployeeAsync(int employeeId, EmployeeDTO employeeDTO)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(employeeId);

            if (existingEmployee == null)
            {
                _logger.LogWarning($"Employee with ID {employeeId} not found.");
                return;
            }
           

            _mapper.Map(employeeDTO, existingEmployee);
            await _employeeRepository.UpdateAsync(existingEmployee);
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);

            if (employee == null)
            {
                _logger.LogWarning($"Employee with ID {employeeId} not found.");
                return;
            }

            await _employeeRepository.DeleteAsync(employee);
        }
    }
}
