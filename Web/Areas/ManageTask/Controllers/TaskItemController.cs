using Application.DTOs;
using Application.Interface;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.ManageTask.Models;

namespace Web.Areas.ManageTask.Controllers
{
    [Area("ManageTask")]
    [Authorize]
    public class TaskItemController : Controller
    {
        private readonly IUser _user;
        private readonly ITaskItemService _taskItemService;

        public TaskItemController(
            IUser user,
            ITaskItemService taskItemService
            )
        {
            _user = user;
            _taskItemService = taskItemService;
        }

        [HttpGet]
        public IActionResult Create(Guid projectId)
        {
            var model = new CreateTaskItemViewModel();
            model.StartDate = DateTime.Now;
            model.ProjectId = projectId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var taskItem = new TaskItemDto
                {
                    ProjectId = model.ProjectId,
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    DueDate = model.DueDate,
                    Priority = model.Priority,
                    Status = model.Status
                };

                var createdTaskItem = await _taskItemService.CreateTaskItemAsync(taskItem);
                return RedirectToAction(nameof(Details), new { id = createdTaskItem.Id });
            }

            return View(model);
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            TaskItemDto taskItem = await _taskItemService.GetTaskItemAsync(Id);
            return View(taskItem);
        }

    }
}
