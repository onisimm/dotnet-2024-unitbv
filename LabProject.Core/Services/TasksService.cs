using LabProject.Core.Mapping;
using LabProject.Database.Dtos.Request;
using LabProject.Database.Dtos.Response;
using LabProject.Database.Repositories;
using LabProject.Infrastructure.Exceptions;

namespace LabProject.Core.Services
{
    public class TasksService
    {
        private TasksRepository tasksRepository { get; set; }
        private ProjectsRepository projectsRepository { get; set; }
        private UsersRepository usersRepository { get; set; }

        public TasksService(TasksRepository tasksRepository, ProjectsRepository projectsRepository, UsersRepository usersRepository)
        {
            this.tasksRepository = tasksRepository;
            this.projectsRepository = projectsRepository;
            this.usersRepository = usersRepository;
        }

        public void AddTask(AddTaskRequest payload)
        {
            var project = payload.ToEntity();

            ValidateProjectId(payload.ProjectId);
            ValidateAssignedUserId(payload.AssignedUserId); 

            tasksRepository.Add(project);
        }

        public void AddTasks(List<AddTaskRequest> payload)
        {
            var projects = payload.ToEntities();

            tasksRepository.AddRange(projects);
        }

        public GetTasksResponse GetTasks(GetTasksRequest payload)
        {
            var tasks = tasksRepository.GetTasks(payload);

            var result = new GetTasksResponse();
            result.Tasks = tasks.ToTaskDtos();
            result.Count = tasksRepository.CountTasks(payload);

            return result;
        }

        public GetTaskDetailsResponse GetTaskDetails(int taskId)
        {
            var task = tasksRepository.GetById(taskId);

            var result = task.ToGetTaskDetailsResponse();

            return result;
        }

        public void EditTask(int taskId, EditTaskRequest payload, int authUserId)
        {
            var task = tasksRepository.GetById(taskId);

            if (task.AssignedUserId != authUserId)
                throw new ForbiddenException("Forbidden");

            ValidateProjectId(payload.ProjectId);
            ValidateAssignedUserId(payload.AssignedUserId);

            tasksRepository.EditTask(task, payload);
        }

        private void ValidateProjectId(int projectId)
        {
            var projectExists = projectsRepository.ValidateProjectId(projectId);

            if (!projectExists)
                throw new ResourceMissingException("Project not found");
        }

        private void ValidateAssignedUserId(int? userId)
        {
            if (userId == null)
                return;

            var userExists = usersRepository.ValidateUserId(userId.Value);

            if (!userExists)
                throw new ResourceMissingException("User not found");
        }

        public void DeleteTask(int taskId)
        {
            var task = tasksRepository.GetById(taskId);

            tasksRepository.DeleteTask(task);
        }
    }
}
