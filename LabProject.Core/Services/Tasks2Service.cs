using LabProject.Database.Repositories;
using Task = LabProject.Database.Entities.Task;

namespace LabProject.Core.Services
{
    public class Tasks2Service
    {
        private TasksRepository tasksRepository { get; set; }

        public Tasks2Service(TasksRepository tasksRepository)
        {
            this.tasksRepository = tasksRepository;
        }

        public List<Task> GetTasks()
        {
            var results = tasksRepository.GetTasks();

            return results;
        }
    }
}
