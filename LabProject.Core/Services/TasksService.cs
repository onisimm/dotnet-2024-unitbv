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
    }
}
