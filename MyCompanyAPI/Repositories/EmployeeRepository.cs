using Microsoft.EntityFrameworkCore;
using MyCompanyAPI.Data;
using MyCompanyAPI.Interfaces.IRepository;
using MyCompanyAPI.Models;

namespace MyCompanyAPI.Repositories
{
    // Repositories/EmployeeRepository.cs
    public class EmployeeRepository : IBaseRepository<Employee>
    {
        private readonly MyCompanyDbContext _dbContext;

        public EmployeeRepository(MyCompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task AddAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _dbContext.Entry(employee).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}