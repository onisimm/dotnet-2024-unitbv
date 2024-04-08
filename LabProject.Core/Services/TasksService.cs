using LabProject.Core.Mapping;
using LabProject.Database.Dtos.Request;
using LabProject.Database.Repositories;
using Task = LabProject.Database.Entities.Task;

namespace LabProject.Core.Services
{
    public class TasksService
    {
        private TasksRepository tasksRepository { get; set; }

        public TasksService(TasksRepository tasksRepository)
        {
            this.tasksRepository = tasksRepository;
        }

        public void AddTask(AddTaskRequest payload)
        {
            var project = payload.ToEntity();

            tasksRepository.Add(project);
        }

        public void AddTasks(List<AddTaskRequest> payload)
        {
            var projects = payload.ToEntities();

            tasksRepository.AddRange(projects);
        }
    }
}
