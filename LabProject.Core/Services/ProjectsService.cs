using LabProject.Database.Repositories;

namespace LabProject.Core.Services
{
    public class ProjectsService
    {
        private ProjectsRepository projectsRepository { get; set; }

        public ProjectsService(ProjectsRepository projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }
    }
}
