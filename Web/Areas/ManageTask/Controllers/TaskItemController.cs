﻿using Application.DTOs;
using Application.Interface;
using Application.Services;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Areas.ManageTask.Models;
using Web.Helper;

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
                    StartDate = DateTime.Now,
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
            TaskItemDto taskItem = await _taskItemService.GetTaskItemWithProjectAsync(Id);
            return View(taskItem);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePriorityAsync(Guid taskItemId, int newPriority)
        {
            TaskItemDto taskItem = await _taskItemService.GetTaskItemAsync(taskItemId);
            taskItem.Priority = (PriorityLevel)newPriority;
            await _taskItemService.UpdateTaskItemPriorityAsync(taskItem.Id, taskItem.Priority);

            return Json(new { updatedPriorityDescription = taskItem.Priority.GetDescription() });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatusAsync(Guid taskItemId, int newStatus)
        {
            TaskItemDto taskItem = await _taskItemService.GetTaskItemAsync(taskItemId);
            taskItem.Status = (Domain.Enums.TaskStatus)newStatus;
            await _taskItemService.UpdateTaskItemStatusAsync(taskItem.Id, taskItem.Status);

            return Json(new { updatedStatusDescription = taskItem.Status.GetDescription() });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTitleAsync(Guid taskItemId, string newTitle)
        {
            TaskItemDto taskItem = await _taskItemService.UpdateTaskItemTitleAsync(taskItemId, newTitle);
            return Json(new { updatedTitleDescription = taskItem.Title });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDescriptionAsync(Guid taskItemId, string newDescription)
        {
            TaskItemDto taskItem = await _taskItemService.UpdateDescriptionAsync(taskItemId, newDescription);
            return Json(new { newDescription = taskItem.Description });
        }
    }
}
