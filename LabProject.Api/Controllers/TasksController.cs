using LabProject.Core.Services;
using LabProject.Database.Dtos.Request;
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
    }
}
