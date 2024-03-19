using Microsoft.EntityFrameworkCore;
using MyCompanyAPI.Data;
using MyCompanyAPI.Interfaces.IRepository;
using MyCompanyAPI.Models;

namespace MyCompanyAPI.Repositories
{
    public class ProjectRepository : IBaseRepository<Project>
    {
        private readonly MyCompanyDbContext _dbContext;

        public ProjectRepository(MyCompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _dbContext.Projects.FindAsync(id);
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task AddAsync(Project project)
        {
            _dbContext.Projects.Add(project);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            _dbContext.Entry(project).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Project project)
        {
            _dbContext.Projects.Remove(project);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

