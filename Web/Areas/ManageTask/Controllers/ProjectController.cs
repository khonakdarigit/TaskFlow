using Application.DTOs;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.ManageTask.Models;

namespace Web.Areas.ManageTask.Controllers
{
    [Area("ManageTask")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IUser _user;
        private readonly IProjectService _projectService;
        public ProjectController(
            IUser user,
            IProjectService projectService
            )
        {
            _user = user;
            _projectService = projectService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model =new CreateProjectViewModel();
            model.StartDate = DateTime.Now; 
            model.EndDate = DateTime.Now.AddDays(5);   
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var project = new ProjectDto
                {
                    Name = model.Name,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    OwnerId=_user.Id
                };

                var createdProject = await _projectService.CreateProjectAsync(project);
                return RedirectToAction("Details", new { id = createdProject.Id });
            }

            return View(model);
        }
    }
}
