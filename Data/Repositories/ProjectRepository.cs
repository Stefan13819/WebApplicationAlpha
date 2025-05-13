
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using static Data.Repositories.ProjectRepository;

namespace Data.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<ProjectEntity>> GetAllAsync();
    Task<ProjectEntity?> GetByIdAsync(string id);
    Task AddAsync(ProjectEntity project);
    Task UpdateAsync(ProjectEntity project);
    Task DeleteAsync(string id);
    Task<bool> ExistsAsync(string id);
}





public class ProjectRepository : IProjectRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<ProjectEntity> _projects;

        public ProjectRepository(DbContext context)
        {
            _context = context;
            _projects = context.Set<ProjectEntity>();
        }

        public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            return await _projects.ToListAsync();
        }

        public async Task<ProjectEntity?> GetByIdAsync(string id)
        {
            return await _projects.FindAsync(id);
        }

        public async Task AddAsync(ProjectEntity project)
        {
            await _projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProjectEntity project)
        {
            _projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var project = await GetByIdAsync(id);
            if (project != null)
            {
                _projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _projects.AnyAsync(p => p.Id == id);
        }
    }


