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
    }
}
