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

        [HttpPost]
        [Route("get-tasks")]
        public IActionResult GetTasks([FromBody] GetTasksRequest payload)
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
            tasksService.EditTask(taskId, payload);

            return Ok("Task has been successfully edited");
        }

        [HttpDelete]
        [Route("delete-task")]
        public IActionResult DeleteTask([FromQuery] int taskId)
        {
            tasksService.DeleteTask(taskId);

            return Ok("Task has been successfully deleted");
        }
    }
}
