

using Data.Entities;
using Data.Repositories;

namespace Business.Services;

public interface IProjectService
{
    Task<IEnumerable<ProjectEntity>> GetAllProjectsAsync();
    Task<ProjectEntity?> GetProjectByIdAsync(string id);
    Task AddProjectAsync(ProjectEntity project);
    Task UpdateProjectAsync(ProjectEntity project);
    Task DeleteProjectAsync(string id);
}

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProjectEntity>> GetAllProjectsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<ProjectEntity?> GetProjectByIdAsync(string id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddProjectAsync(ProjectEntity project)
    {
        await _repository.AddAsync(project);
    }

    public async Task UpdateProjectAsync(ProjectEntity project)
    {
        if (await _repository.ExistsAsync(project.Id))
        {
            await _repository.UpdateAsync(project);
        }
        else
        {
            throw new KeyNotFoundException("Project not found.");
        }
    }

    public async Task DeleteProjectAsync(string id)
    {
        await _repository.DeleteAsync(id);
    }
}
