using LabProject.Core.Services;
using LabProject.Database.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace LabProject.Api.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private ProjectsService projectsService { get; set; }

        public ProjectsController(ProjectsService projectsService)
        {
            this.projectsService = projectsService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddProject([FromBody] AddProjectRequest payload)
        {
            projectsService.AddProject(payload);

            return Ok("Project has been successfully added");
        }

        [HttpPost]
        [Route("{projectId}/assign-user")]
        public IActionResult AssignUser([FromRoute] int projectId, [FromQuery] int userId)
        {
            projectsService.AssignUser(projectId, userId);

            return Ok("User has been successfully assigned");
        }
    }
}
