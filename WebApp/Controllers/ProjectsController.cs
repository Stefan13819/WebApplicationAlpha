using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Data.Entities;

namespace WebApp.Controllers;

[Authorize]


public class ProjectsController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    // GET: Projects
    public async Task<IActionResult> Projects()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        return View(projects);
    }

    // POST: Projects/Create
    [HttpPost]

    public async Task<IActionResult> Create(ProjectEntity project)
    {
        if (!ModelState.IsValid)
            return View("Projects", await _projectService.GetAllProjectsAsync()); 

        await _projectService.AddProjectAsync(project);
        return RedirectToAction("Projects");
    }

    // GET: Projects/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null)
            return NotFound();

        return View(project);
       
    }

    // POST: Projects/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(ProjectEntity model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _projectService.UpdateProjectAsync(model);
        return RedirectToAction("Projects");
    }

    // POST: Projects/Delete/5
    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        await _projectService.DeleteProjectAsync(id);
        return RedirectToAction("Projects");
    }


}
