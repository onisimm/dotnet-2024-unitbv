using LabProject.Core.Services;
using LabProject.Database.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace LabProject.Api.Controllers
{
    [Route("api/tasks")]
    [Authorize]
    public class TasksController : BaseController
    {
        private TasksService tasksService { get; set; }

        public TasksController(
            TasksService tasksService
            )
        {
            this.tasksService = tasksService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddTask([FromBody] AddTaskRequest payload)
        {
            tasksService.AddTask(payload);

            return Ok("Task has been successfully created");
        }

        [HttpPost]
        [Route("add-tasks")]
        public IActionResult AddTasks([FromBody] List<AddTaskRequest> payload)
        {
            tasksService.AddTasks(payload);

            return Ok("Tasks have been successfully created");
        }

        [HttpPost]
        [Route("get-tasks")]
        public IActionResult GetTasks(GetTasksRequest payload)
        {
            var results = tasksService.GetTasks(payload);

            return Ok(results);
        }

        [HttpGet]
        [Route("{taskId}/get-details")]
        public IActionResult GetTaskDetails([FromRoute] int taskId)
        {
            var result = tasksService.GetTaskDetails(taskId);

            return Ok(result);
        }

        [HttpPut]
        [Route("{taskId}/edit-task")]
        public IActionResult EditTask([FromRoute] int taskId, [FromBody] EditTaskRequest payload)
        {
            var authUserId = GetUserId();
            tasksService.EditTask(taskId, payload);

            return Ok("Task has been successfully edited");
        }

        [HttpDelete]
        [Route("delete-task")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteTask([FromQuery] int taskId)
        {
            tasksService.DeleteTask(taskId);

            return Ok("Task has been successfully deleted");
        }
    }
}
