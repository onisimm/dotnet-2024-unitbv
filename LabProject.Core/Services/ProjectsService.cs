using LabProject.Core.Mapping;
using LabProject.Database.Dtos.Request;
using LabProject.Database.Entities;
using LabProject.Database.Repositories;

namespace LabProject.Core.Services
{
    public class ProjectsService
    {
        private ProjectsRepository projectsRepository { get; set; }
        private UserProjectsRepository userProjectsRepository { get; set; }

        public ProjectsService(
            ProjectsRepository projectsRepository, 
            UserProjectsRepository userProjectsRepository)
        {
            this.projectsRepository = projectsRepository;
            this.userProjectsRepository = userProjectsRepository;
        }

        public void AddProject(AddProjectRequest payload)
        {
            var project = payload.ToEntity();

            projectsRepository.Add(project);
        }

        public void AssignUser(int projectId, int userId)
        {
            var userProject = new UserProject();
            userProject.UserId = userId;
            userProject.ProjectId = projectId;
            userProject.DateCreated = DateTime.UtcNow;
            userProject.DateUpdated = DateTime.UtcNow;

            userProjectsRepository.Add(userProject);
        }
    }
}
