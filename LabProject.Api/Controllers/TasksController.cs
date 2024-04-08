using LabProject.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabProject.Api.Controllers
{
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private TasksService tasksService { get; set; }

        public TasksController(
            TasksService tasksService
            )
        {
            this.tasksService = tasksService;
        }

        [HttpGet]
        [Route("get-tasks")]
        public IActionResult GetTasks()
        {
            var results = tasksService.GetTasks();

            return Ok(results);
        }

        [HttpGet]
        [Route("get-task-details")]
        public IActionResult GetTaskDetails(int taskId)
        {
            var result = tasksService.GetTaskDetails(taskId);

            return Ok(result);
        }
    }
}
