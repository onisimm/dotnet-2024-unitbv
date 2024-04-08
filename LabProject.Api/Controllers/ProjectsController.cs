using LabProject.Core.Services;
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
    }
}
